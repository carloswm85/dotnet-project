namespace Telerik.Project.Management.Services;

public interface IStorageProvider
{
    bool Exists(string fileName);
    IEnumerable<string> Find(string filePattern);
    Stream Create(string fileName);
    Stream Open(string fileName);
    void Delete(string fileName);
}