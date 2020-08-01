using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Database.Persistence.Mapping
{
    public class MandatorMapping : BaseEntityMap<Mandator, int>
    {
        public MandatorMapping()
        {
            Map(x => x.UserId);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
        }
    }
}
