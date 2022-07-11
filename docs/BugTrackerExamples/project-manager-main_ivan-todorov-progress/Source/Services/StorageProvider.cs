namespace Telerik.Project.Management.Services;

public class StorageProvider : IStorageProvider
{
    private readonly string basePath;

    public StorageProvider(IWebHostEnvironment hostEnvironment)
    {
        this.basePath = Path.Combine(hostEnvironment.ContentRootPath, "Data");

        if (!Directory.Exists(this.basePath))
        {
            Directory.CreateDirectory(this.basePath);
        }
    }

    public bool Exists(string fileName)
    {
        var filePath = Path.Combine(this.basePath, fileName);

        return File.Exists(filePath);
    }

    public IEnumerable<string> Find(string filePattern)
    {
        var filePaths = Directory.EnumerateFiles(this.basePath, filePattern);

        foreach (var filePath in filePaths)
        {
            var fileName = Path.GetFileName(filePath);

            yield return fileName;
        }
    }

    public Stream Create(string fileName)
    {
        var filePath = Path.Combine(this.basePath, fileName);

        return File.Create(filePath);
    }

    public Stream Open(string fileName)
    {
        var filePath = Path.Combine(this.basePath, fileName);

        return File.OpenRead(filePath);
    }

    public void Delete(string fileName)
    {
        var filePath = Path.Combine(this.basePath, fileName);

        if (File.Exists(fileName))
        {
            File.Delete(filePath);
        }
    }
}
