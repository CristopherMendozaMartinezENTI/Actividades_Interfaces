using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;

public class MenuPanelView : MonoBehaviour
{
    [SerializeField] private RectTransform _homeContainer;
    [SerializeField] private RectTransform _scoreContainer;
    [SerializeField] private RectTransform _settingsContainer;

    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private Button _settingsButton;

    private MenuPanelViewModel _viewModel;

    public void SetViewModel(MenuPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _homeButton.onClick.AddListener(() => {
            _viewModel.HomeButtonPressed.Execute();
            Debug.Log("Click on Home");
        }
        );

        _scoreButton.onClick.AddListener(() => {
            _viewModel.ScoreButtonPressed.Execute();
            Debug.Log("Click on Score");
        }
      );
    }
}
