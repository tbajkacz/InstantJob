namespace InstantJob.Modules.Users.Application.Common.Abstractions
{
    public interface IHashService
    {
        bool CompareHashes(string password, string hash);

        string Hash(string password);
    }
}