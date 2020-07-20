using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.Interfaces
{
    public interface IDataSeeder
    {
        Task SeedAsync();
    }
}
