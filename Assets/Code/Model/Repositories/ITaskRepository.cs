using System.Collections.Generic;

public interface ITaskRepository
{
    IReadOnlyList<TaskEntity> GetAll();
    TaskEntity Create(string text);
    void Delete(int id);
}