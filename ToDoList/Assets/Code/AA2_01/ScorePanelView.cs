using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScorePanelView : MonoBehaviour
{
    private ScorePanelViewModel _viewModel;

    public void SetViewModel(ScorePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            });
    }
}
