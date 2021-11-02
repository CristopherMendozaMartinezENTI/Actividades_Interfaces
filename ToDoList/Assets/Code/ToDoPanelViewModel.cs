using UniRx;

public class ToDoPanelViewModel 
{
    public readonly ReactiveCommand AddTaskButtonPressed;
    public readonly ReactiveCollection<TaskItemViewModel> Tasks;

    public ToDoPanelViewModel()
    {
        AddTaskButtonPressed = new ReactiveCommand();
        Tasks = new ReactiveCollection<TaskItemViewModel>();
    }
}
