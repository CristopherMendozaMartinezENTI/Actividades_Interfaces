using System;

[Serializable]
public class TaskDto
{
    public int Id;
    public string Text;

    public TaskDto(int id, string text)
    {
        Id = id;
        Text = text;
    }
}
