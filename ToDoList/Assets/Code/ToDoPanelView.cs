using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;

public class ToDoPanelView : MonoBehaviour
{
    [SerializeField] private TaskItemView _taskItemViewPrefab;
    [SerializeField] private RectTransform _taskItemContainer;

    [SerializeField] private Button _addTaskButton;
    private ToDoPanelViewModel _viewModel;

    private List<TaskItemView> _instantiatedTaskItems;

    public void SetViewModel(ToDoPanelViewModel viewModel)
    {
        _instantiatedTaskItems = new List<TaskItemView>();
        _viewModel = viewModel;

        _viewModel
            .Tasks
            .ObserveAdd()
            .Subscribe(InstantiateTask);
        
        _viewModel
            .Tasks
            .ObserveRemove()
            .Subscribe(RemoveTask);

        _addTaskButton.onClick.AddListener(() => {
            _viewModel.AddTaskButtonPressed.Execute();
            }
        );
    }

    private void RemoveTask(CollectionRemoveEvent<TaskItemViewModel> taskItemViewModel)
    {
        var item = _instantiatedTaskItems
            .First(item => item.Id.Equals(taskItemViewModel.Value.Id));
      
        Destroy(item.gameObject);
        _instantiatedTaskItems.Remove(item);
    }

    private void InstantiateTask(CollectionAddEvent<TaskItemViewModel> taskEntity)
    {
        var taskItemView = Instantiate(_taskItemViewPrefab, _taskItemContainer);
        taskItemView.SetViewModel(taskEntity.Value);

        _instantiatedTaskItems.Add(taskItemView);
    }
}
