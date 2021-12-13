public class TaskDeletedEvent{
    public readonly int Id;

    public TaskDeletedEvent(int id)
    {
        Id = id;
    }
}