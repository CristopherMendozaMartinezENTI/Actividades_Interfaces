using UnityEngine;


public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private ToDoPanelView _toDoPanelPrefab; 
    [SerializeField] private TaskPanelView _taskPanelPrefab; 
    
    private void Awake()
    {
        var toDoPanelView = Instantiate(_toDoPanelPrefab, _canvasParent);
        var taskPanelView = Instantiate(_taskPanelPrefab, _canvasParent);

        var taskPanelViewModel = new TaskPanelViewModel();
        var toDoPanelViewModel = new ToDoPanelViewModel();


        taskPanelView.SetViewModel(taskPanelViewModel);
        toDoPanelView.SetViewModel(toDoPanelViewModel);

        new TaskPanelController(taskPanelViewModel, toDoPanelViewModel);
        new ToDoPanelController(toDoPanelViewModel, taskPanelViewModel);
        // new ToDoPanelPresenter();

    }
}
