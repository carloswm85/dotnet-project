namespace Telerik.Project.Management.Models;

public static class DiffChanges
{
    public static IEnumerable<ChangeInfo> Get(ProjectInfo projectInfo)
    {
        if (projectInfo.Title is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(projectInfo.Title),
                NewValue = projectInfo.Title
            };
        }

        if (projectInfo.Image is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(projectInfo.Image),
                NewValue = projectInfo.Image
            };
        }

        if (projectInfo.Description is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(projectInfo.Description),
                NewValue = projectInfo.Description
            };
        }
    }

    public static IEnumerable<ChangeInfo> Get(ProjectInfo oldInfo, ProjectInfo newInfo)
    {
        if (oldInfo.Title != newInfo.Title)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Title),
                OldValue = oldInfo.Title,
                NewValue = newInfo.Title
            };
        }

        if (oldInfo.Image != newInfo.Image)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Image),
                NewValue = newInfo.Image
            };
        }

        if (oldInfo.Description != newInfo.Description)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Description),
                NewValue = newInfo.Description
            };
        }
    }

    public static IEnumerable<ChangeInfo> Get(TaskInfo newInfo)
    {
        yield return new ChangeInfo
        {
            Name = nameof(newInfo.Type),
            NewValue = newInfo.Type
        };

        yield return new ChangeInfo
        {
            Name = nameof(newInfo.Status),
            NewValue = newInfo.Status
        };

        yield return new ChangeInfo
        {
            Name = nameof(newInfo.Priority),
            NewValue = newInfo.Priority
        };

        if (newInfo.Title is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Title),
                NewValue = newInfo.Title
            };
        }

        if (newInfo.Description is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Description),
                NewValue = newInfo.Description
            };
        }

        if (newInfo.Assignee is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Assignee),
                NewValue = newInfo.Assignee
            };
        }

        if (newInfo.Estimate is not null)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Estimate),
                NewValue = newInfo.Estimate
            };
        }
    }

    public static IEnumerable<ChangeInfo> Get(TaskInfo oldInfo, TaskInfo newInfo)
    {
        if (oldInfo.Type != newInfo.Type)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Type),
                OldValue = oldInfo.Type,
                NewValue = newInfo.Type
            };
        }

        if (oldInfo.Status != newInfo.Status)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Status),
                OldValue = oldInfo.Status,
                NewValue = newInfo.Status
            };
        }

        if (oldInfo.Priority != newInfo.Priority)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Priority),
                OldValue = oldInfo.Priority,
                NewValue = newInfo.Priority
            };
        }

        if (oldInfo.Title != newInfo.Title)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Title),
                OldValue = oldInfo.Title,
                NewValue = newInfo.Title
            };
        }

        if (oldInfo.Description != newInfo.Description)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Description),
                OldValue = oldInfo.Description,
                NewValue = newInfo.Description
            };
        }

        if (oldInfo.Assignee != newInfo.Assignee)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Assignee),
                OldValue = oldInfo.Assignee,
                NewValue = newInfo.Assignee
            };
        }

        if (oldInfo.Estimate != newInfo.Estimate)
        {
            yield return new ChangeInfo
            {
                Name = nameof(newInfo.Estimate),
                OldValue = oldInfo.Estimate,
                NewValue = newInfo.Estimate
            };
        }
    }
}
