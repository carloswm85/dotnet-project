using Telerik.Project.Management.Models;

namespace Telerik.Project.Management.Services;

public class ProjectService : IProjectService
{
    private readonly IStorageService storageService;

    public ProjectService(IStorageService storageService)
    {
        this.storageService = storageService;
    }

    public async Task<IEnumerable<ProjectInfo>> GetProjectsAsync()
    {
        return await this.storageService.LoadProjectsAsync();
    }

    public async Task<ProjectInfo> GetProjectAsync(string projectId)
    {
        return await this.storageService.LoadProjectAsync(projectId);
    }

    public async Task<ProjectInfo> CreateProjectAsync(ProjectInfo projectInfo)
    {
        var projectId = UniqueKey.New();
        var currentTime = DateTime.Now;

        projectInfo.Id = projectId;
        projectInfo.Created = currentTime;
        projectInfo.Modified = currentTime;

        var changeId = UniqueKey.New();
        var changeSet = new ChangeSet();

        changeSet.Id = changeId;
        changeSet.ParentId = projectId;
        changeSet.Modified = currentTime;

        var changeInfos = DiffChanges.Get(projectInfo);

        changeSet.Changes.AddRange(changeInfos);

        await this.storageService.SaveProjectAsync(projectInfo);
        await this.storageService.SaveChangeAsync(changeSet);

        return projectInfo;
    }

    public async Task<ProjectInfo> UpdateProjectAsync(ProjectInfo projectInfo)
    {
        var projectId = projectInfo.Id;

        if (projectId is null)
        {
            throw new ArgumentNullException(nameof(projectId));
        }

        var currentTime = DateTime.Now;

        projectInfo.Modified = currentTime;

        var changeId = UniqueKey.New();
        var changeSet = new ChangeSet();

        changeSet.Id = changeId;
        changeSet.ParentId = projectId;
        changeSet.Modified = currentTime;

        var storedInfo = await this.storageService.LoadProjectAsync(projectId);
        var changeInfos = DiffChanges.Get(storedInfo, projectInfo);

        changeSet.Changes.AddRange(changeInfos);

        await this.storageService.SaveProjectAsync(projectInfo);
        await this.storageService.SaveChangeAsync(changeSet);

        return projectInfo;
    }
}
