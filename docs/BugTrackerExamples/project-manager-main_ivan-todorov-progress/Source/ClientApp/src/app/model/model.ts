export interface ProjectInfo {
  id?: string;
  title?: string;
  image?: string;
  description?: string;
  created?: Date;
  modified?: Date;
}

export enum TaskType {
  story,
  bug
}

export enum TaskStatus {
  toDo,
  inProgress,
  readyForTest,
  done
}

export enum TaskPriority {
  low,
  normal,
  high,
  critical
}

export interface TaskInfo {
  id?: string;
  projectId?: string;
  type?: TaskType;
  status?: TaskStatus;
  priority: TaskPriority;
  title?: string;
  description?: string;
  assignee?: string;
  estimate?: number;
  created?: Date;
  modified?: Date;
}

export interface ChangeSet {
  id?: string;
  parentId?: string;
  modified?: Date;
  changes?: ChangeInfo[];
}

export interface ChangeInfo {
  name?: string;
  oldValue?: object;
  newValue?: object;
}
