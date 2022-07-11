using Telerik.Project.Management.Models;

namespace Telerik.Project.Management.Services;

public interface IStorageService
{
    Task<IEnumerable<ProjectInfo>> LoadProjectsAsync();
    Task<ProjectInfo> LoadProjectAsync(string projectId);
    Task SaveProjectAsync(ProjectInfo projectInfo);
    Task<IEnumerable<TaskInfo>> LoadTasksAsync(string projectId);
    Task<TaskInfo> LoadTaskAsync(string taskId);
    Task SaveTaskAsync(TaskInfo taskInfo);
    Task<IEnumerable<ChangeSet>> LoadChangesAsync(string parentId);
    Task<ChangeSet> LoadChangeAsync(string changeId);
    Task SaveChangeAsync(ChangeSet changeSet);
}