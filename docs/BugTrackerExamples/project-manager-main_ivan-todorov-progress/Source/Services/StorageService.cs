using System.Text.Json;
using Telerik.Project.Management.Models;

namespace Telerik.Project.Management.Services;

public class StorageService : IStorageService
{
    private readonly IStorageProvider storageProvider;

    public StorageService(IStorageProvider storageProvider)
    {
        this.storageProvider = storageProvider;
    }

    public async Task<IEnumerable<ProjectInfo>> LoadProjectsAsync()
    {
        var projectInfos = new List<ProjectInfo>();
        var filePattern = GetProjectName("*");
        var fileNames = this.storageProvider.Find(filePattern);

        foreach (var fileName in fileNames)
        {
            using var fileStream = this.storageProvider.Open(fileName);
            var projectInfo = await JsonSerializer.DeserializeAsync<ProjectInfo>(fileStream);

            if (projectInfo is not null)
            {
                projectInfos.Add(projectInfo);
            }
        }

        return projectInfos;
    }

    public async Task<ProjectInfo> LoadProjectAsync(string projectId)
    {
        var fileName = GetProjectName(projectId);

        if (this.storageProvider.Exists(fileName))
        {
            using var fileStream = this.storageProvider.Open(fileName);
            var projectInfo = await JsonSerializer.DeserializeAsync<ProjectInfo>(fileStream);

            if (projectInfo is not null)
            {
                return projectInfo;
            }
        }

        var errorMessage = $"Project not found: {projectId}.";

        throw new ArgumentException(errorMessage);
    }

    public async Task SaveProjectAsync(ProjectInfo projectInfo)
    {
        var projectId = projectInfo.Id;

        if (projectId is null)
        {
            throw new ArgumentNullException(nameof(projectId));
        }

        var fileName = GetProjectName(projectId);
        using var fileStream = this.storageProvider.Create(fileName);

        await JsonSerializer.SerializeAsync(fileStream, projectInfo);
    }

    public async Task<IEnumerable<TaskInfo>> LoadTasksAsync(string projectId)
    {
        var taskInfos = new List<TaskInfo>();
        var filePattern = GetTaskName(projectId, "*");
        var fileNames = this.storageProvider.Find(filePattern);

        foreach (var fileName in fileNames)
        {
            using var fileStream = this.storageProvider.Open(fileName);
            var taskInfo = await JsonSerializer.DeserializeAsync<TaskInfo>(fileStream);

            if (taskInfo is not null)
            {
                taskInfos.Add(taskInfo);
            }
        }

        return taskInfos;
    }

    public async Task<TaskInfo> LoadTaskAsync(string taskId)
    {
        var filePattern = GetTaskName("*", taskId);
        var fileNames = this.storageProvider.Find(filePattern);

        foreach (var fileName in fileNames)
        {
            using var fileStream = this.storageProvider.Open(fileName);
            var taskInfo = await JsonSerializer.DeserializeAsync<TaskInfo>(fileStream);

            if (taskInfo is not null)
            {
                return taskInfo;
            }
        }

        var errorMessage = $"Task not found: {taskId}.";

        throw new ArgumentException(errorMessage);
    }

    public async Task SaveTaskAsync(TaskInfo taskInfo)
    {
        var taskId = taskInfo.Id;
        var projectId = taskInfo.ProjectId;

        if (taskId is null)
        {
            throw new ArgumentNullException(nameof(taskId));
        }

        if (projectId is null)
        {
            throw new ArgumentNullException(nameof(projectId));
        }

        var fileName = GetTaskName(projectId, taskId);
        using var fileStream = this.storageProvider.Create(fileName);

        await JsonSerializer.SerializeAsync(fileStream, taskInfo);
    }

    public async Task<IEnumerable<ChangeSet>> LoadChangesAsync(string parentId)
    {
        var changeSets = new List<ChangeSet>();
        var filePattern = GetChangeName(parentId, "*");
        var fileNames = this.storageProvider.Find(filePattern);

        foreach (var fileName in fileNames)
        {
            var fileStream = this.storageProvider.Open(fileName);
            var changeSet = await JsonSerializer.DeserializeAsync<ChangeSet>(fileStream);

            if (changeSet is not null)
            {
                changeSets.Add(changeSet);
            }
        }

        return changeSets;
    }

    public async Task<ChangeSet> LoadChangeAsync(string changeId)
    {
        var filePattern = GetChangeName("*", changeId);
        var fileNames = this.storageProvider.Find(filePattern);

        foreach (var fileName in fileNames)
        {
            var fileStream = this.storageProvider.Open(fileName);
            var changeSet = await JsonSerializer.DeserializeAsync<ChangeSet>(fileStream);

            if (changeSet is not null)
            {
                return changeSet;
            }
        }

        var errorMessage = $"Change not found: {changeId}.";

        throw new ArgumentException(errorMessage);
    }

    public async Task SaveChangeAsync(ChangeSet changeSet)
    {
        var changeId = changeSet.Id;
        var parentId = changeSet.ParentId;

        if (changeId is null)
        {
            throw new ArgumentNullException(nameof(changeId));
        }

        if (parentId is null)
        {
            throw new ArgumentNullException(nameof(parentId));
        }

        var fileName = GetChangeName(parentId, changeId);
        using var fileStream = this.storageProvider.Create(fileName);

        await JsonSerializer.SerializeAsync(fileStream, changeSet);
    }

    private static string GetProjectName(string projectId)
    {
        return $"Project-{projectId}.json";
    }

    private static string GetTaskName(string projectId, string taskId)
    {
        return $"Task-{projectId}-{taskId}.json";
    }

    private static string GetChangeName(string parentId, string changeId)
    {
        return $"Change-{parentId}-{changeId}.json";
    }
}
