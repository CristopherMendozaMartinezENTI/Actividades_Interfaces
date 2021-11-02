using UniRx;
public class TaskPanelController
{
    private int _lastUsedId = -1;

    public TaskPanelController(TaskPanelViewModel taskPanelViewModel,
        ToDoPanelViewModel toDoPanelViewModel)
    {
        taskPanelViewModel.OnDeleteButtonPressed.Subscribe(
            (_)=> {
                taskPanelViewModel.IsVisible.Value = false;
                }
            );

        taskPanelViewModel.OnAddButtonPressed.Subscribe(
            (taskText) =>
            {
                _lastUsedId += 1;
               // var taskEntity = new TaskEntity(_lastUsedId, taskText);

                var taskItemViewModel = new TaskItemViewModel(_lastUsedId, taskText);
                taskItemViewModel
                .OnDeleteButtonPressed
                .Subscribe(_ => {
                    toDoPanelViewModel.Tasks.Remove(taskItemViewModel);
                });
                toDoPanelViewModel.Tasks.Add(taskItemViewModel);

                taskPanelViewModel.IsVisible.Value = false;
            }
        );
    }
}
