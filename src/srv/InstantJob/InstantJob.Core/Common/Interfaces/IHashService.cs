namespace InstantJob.Core.Common.Interfaces
{
    public interface IHashService
    {
        bool CompareHashes(string password, string hash);

        string Hash(string password);
    }
}