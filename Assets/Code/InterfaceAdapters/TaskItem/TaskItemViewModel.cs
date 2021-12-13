using Code.InterfaceAdapters;
using UniRx;

public class TaskItemViewModel : ViewModel
{
    public readonly int Id;

    public readonly ReactiveProperty<string> Text;
    public readonly ReactiveCommand OnDeleteButtonPressed;
    public readonly ReactiveCommand OnEditButtonPressed;

    public TaskItemViewModel(int id, string taskText)
    {
        Id = id;

        Text = new ReactiveProperty<string>(taskText)
            .AddTo(_disposables);
        OnDeleteButtonPressed = new ReactiveCommand()
            .AddTo(_disposables);
        OnEditButtonPressed = new ReactiveCommand()
            .AddTo(_disposables);
    }
}
