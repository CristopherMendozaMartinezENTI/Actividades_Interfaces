using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SettingsPanelView : MonoBehaviour
{
    private SettingsPanelViewModel _viewModel;

    public void SetViewModel(SettingsPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) =>
            {
                gameObject.SetActive(isVisible);
            });
    }
}
