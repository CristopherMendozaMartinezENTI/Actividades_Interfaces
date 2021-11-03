using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HomePanelView : MonoBehaviour
{
    private HomePanelViewModel _viewModel;

    public void SetViewModel(HomePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            });
    }
}
