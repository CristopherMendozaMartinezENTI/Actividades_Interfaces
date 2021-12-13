using System;
using System.Collections.Generic;

[Serializable]
public class TasksDto
{
    public List<TaskDto> Tasks;

    public TasksDto(List<TaskDto> tasks)
    {
        Tasks = tasks;
    }
}
