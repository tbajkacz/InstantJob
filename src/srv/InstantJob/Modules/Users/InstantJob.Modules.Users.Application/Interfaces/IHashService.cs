namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface IHashService
    {
        bool CompareHashes(string password, string hash);

        string Hash(string password);
    }
}