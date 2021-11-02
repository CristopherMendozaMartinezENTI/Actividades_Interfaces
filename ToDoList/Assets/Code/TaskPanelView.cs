using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class TaskPanelView : MonoBehaviour
{
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _addButton;
    [SerializeField] private TMP_InputField _inputField;

    private TaskPanelViewModel _viewModel;

    public void SetViewModel(TaskPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible)=> {
                gameObject.SetActive(isVisible);
            });
        _viewModel
            .TaskName
            .Subscribe(taskName =>
            {
                _inputField.SetTextWithoutNotify(taskName);
            });

        _deleteButton.onClick.AddListener(() =>
        {
            _viewModel.OnDeleteButtonPressed.Execute();
        });

        _addButton.onClick.AddListener(() =>
        {
            _viewModel.OnAddButtonPressed.Execute(_inputField.text);
        });
    }
}
