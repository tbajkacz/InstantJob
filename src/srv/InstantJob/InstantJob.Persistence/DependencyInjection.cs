using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InstantJob.Persistence.Conventions;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Tool.hbm2ddl;
using System.Data;

namespace InstantJob.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            var fact = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(connectionString)
                                                      .IsolationLevel(IsolationLevel.ReadCommitted))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(DependencyInjection).Assembly)
                                .Conventions.Add<IncrementIdConvention>()
                                .Conventions.Add<InstantJobTableNameConvention>())
                .ExposeConfiguration(x =>
                    new SchemaUpdate(x).Execute(false, true))
                .BuildSessionFactory();
            return services.AddScoped(p => fact.OpenSession());
        }
    }
}
