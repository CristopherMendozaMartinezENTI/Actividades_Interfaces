using UniRx;

public class TaskPanelViewModel 
{
    public readonly ReactiveCommand OnDeleteButtonPressed;
    public readonly ReactiveCommand<string> OnAddButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<string> TaskName;

    public TaskPanelViewModel()
    {
        OnDeleteButtonPressed = new ReactiveCommand();
        OnAddButtonPressed = new ReactiveCommand<string>();
        
        IsVisible = new ReactiveProperty<bool>();
        TaskName = new ReactiveProperty<string>(string.Empty);
    }
}
