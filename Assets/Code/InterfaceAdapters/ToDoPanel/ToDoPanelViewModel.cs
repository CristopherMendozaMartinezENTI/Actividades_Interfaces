using Code.InterfaceAdapters;
using UniRx;

public class ToDoPanelViewModel : ViewModel
{
    public readonly ReactiveCommand AddTaskButtonPressed;
    public readonly ReactiveCollection<TaskItemViewModel> Tasks;

    public ToDoPanelViewModel()
    {
        AddTaskButtonPressed = new ReactiveCommand()
            .AddTo(_disposables);
        Tasks = new ReactiveCollection<TaskItemViewModel>()
            .AddTo(_disposables);
    }
}
