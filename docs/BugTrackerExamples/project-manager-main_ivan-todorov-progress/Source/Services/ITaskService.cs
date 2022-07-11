using Telerik.Project.Management.Models;

namespace Telerik.Project.Management.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskInfo>> GetTasksAsync(string projectId);
    Task<TaskInfo> GetTaskAsync(string taskId);
    Task<TaskInfo> CreateTaskAsync(TaskInfo taskInfo);
    Task<TaskInfo> UpdateTaskAsync(TaskInfo taskInfo);
}