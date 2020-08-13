namespace InstantJob.Modules.Users.Application.UserRegistrations.Abstractions
{
    public interface IHashService
    {
        bool CompareHashes(string password, string hash);

        string Hash(string password);
    }
}