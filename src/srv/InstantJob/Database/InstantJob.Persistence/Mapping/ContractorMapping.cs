using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Database.Persistence.Mapping
{
    internal class ContractorMapping : BaseEntityMap<Contractor, int>
    {
        public ContractorMapping()
        {
            Map(x => x.UserId);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
        }
    }
}
