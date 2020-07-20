using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Infrastructure.Data;
using InstantJob.Persistence.Conventions;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Tool.hbm2ddl;
using System.Data;

namespace InstantJob.Database.Persistence.Configuration
{
    public static class AddPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            var fact = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(connectionString)
                                                      .IsolationLevel(IsolationLevel.ReadCommitted))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(AddPersistenceExtension).Assembly)
                                .Conventions.Add<IncrementIdConvention>()
                                .Conventions.Add<InstantJobTableNameConvention>())
                .ExposeConfiguration(x =>
                    new SchemaUpdate(x).Execute(false, true))
                .BuildSessionFactory();
            return services.AddScoped(p => fact.OpenSession())
                           .AddScoped<IUnitOfWork, NHibernateUnitOfWork>();
        }
    }
}
