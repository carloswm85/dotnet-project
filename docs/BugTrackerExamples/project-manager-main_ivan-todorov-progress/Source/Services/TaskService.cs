using Telerik.Project.Management.Models;

namespace Telerik.Project.Management.Services;

public class TaskService : ITaskService
{
    private readonly IStorageService storageService;

    public TaskService(IStorageService storageService)
    {
        this.storageService = storageService;
    }

    public async Task<IEnumerable<TaskInfo>> GetTasksAsync(string projectId)
    {
        return await this.storageService.LoadTasksAsync(projectId);
    }

    public async Task<TaskInfo> GetTaskAsync(string taskId)
    {
        return await this.storageService.LoadTaskAsync(taskId);
    }

    public async Task<TaskInfo> CreateTaskAsync(TaskInfo taskInfo)
    {
        var projectId = taskInfo.ProjectId;

        if (projectId is null)
        {
            throw new ArgumentNullException(nameof(projectId));
        }

        var taskId = UniqueKey.New();
        var currentTime = DateTime.Now;

        taskInfo.Id = taskId;
        taskInfo.Created = currentTime;
        taskInfo.Modified = currentTime;

        var changeId = UniqueKey.New();
        var changeSet = new ChangeSet();

        changeSet.Id = changeId;
        changeSet.ParentId = taskId;
        changeSet.Modified = currentTime;

        var changeInfos = DiffChanges.Get(taskInfo);

        changeSet.Changes.AddRange(changeInfos);

        await this.storageService.SaveTaskAsync(taskInfo);
        await this.storageService.SaveChangeAsync(changeSet);

        return taskInfo;
    }

    public async Task<TaskInfo> UpdateTaskAsync(TaskInfo taskInfo)
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

        var currentTime = DateTime.Now;

        taskInfo.Modified = currentTime;

        var changeId = UniqueKey.New();
        var changeSet = new ChangeSet();

        changeSet.Id = changeId;
        changeSet.ParentId = taskId;
        changeSet.Modified = currentTime;

        var storedInfo = await this.storageService.LoadTaskAsync(taskId);
        var changeInfos = DiffChanges.Get(storedInfo, taskInfo);

        changeSet.Changes.AddRange(changeInfos);

        await this.storageService.SaveTaskAsync(taskInfo);
        await this.storageService.SaveChangeAsync(changeSet);

        return taskInfo;
    }
}
