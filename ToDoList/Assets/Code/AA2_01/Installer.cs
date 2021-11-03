using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;

    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;
    [SerializeField] private ScorePanelView _scorePanelPrefab;
    [SerializeField] private SettingsPanelView _settingsPanelPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        var settingPanelView = Instantiate(_settingsPanelPrefab, _CanvasParent);
        var scorePanelView = Instantiate(_scorePanelPrefab, _CanvasParent);
        var homePanelView = Instantiate(_homePanelPrefab, _CanvasParent);
        var buttonsPanel = Instantiate(_menuPanelPrefab, _CanvasParent);

        var menuPanelViewModel = new MenuPanelViewModel();
        var homePanelViewModel = new HomePanelViewModel();
        var scorePanelViewModel = new ScorePanelViewModel();
        var settingsPanelViewModel = new SettingsPanelViewModel();

        buttonsPanel.SetViewModel(menuPanelViewModel);
        homePanelView.SetViewModel(homePanelViewModel);
        scorePanelView.SetViewModel(scorePanelViewModel);
        settingPanelView.SetViewModel(settingsPanelViewModel);

        new MenuPanelController(menuPanelViewModel, homePanelViewModel, scorePanelViewModel, settingsPanelViewModel);
    }
}
