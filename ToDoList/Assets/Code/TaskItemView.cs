using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TaskItemView : MonoBehaviour
{
    public int Id { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _editButton;

    public void SetViewModel(TaskItemViewModel taskItemViewModel)
    {
        Id = taskItemViewModel.Id;

        taskItemViewModel
            .Text
            .Subscribe(newText =>
            {
                _text.SetText(newText);
            });

        
        _deleteButton.onClick.AddListener(()=> {
            taskItemViewModel.OnDeleteButtonPressed.Execute();
        });

        _editButton.onClick.AddListener(()=> {
            taskItemViewModel.OnEditButtonPressed.Execute();
        });
    }
}
