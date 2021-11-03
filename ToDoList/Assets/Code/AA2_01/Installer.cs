using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;
    [SerializeField] private RectTransform _buttonCanvasParent;
    [SerializeField] private RectTransform _homeCanvasParent;
    [SerializeField] private RectTransform _scoreCanvasParent;
    [SerializeField] private RectTransform _settingCanvasParent;

    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;

    [SerializeField] private ScorePanelView _scorePanelPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        var settingPanelView = Instantiate(_settingCanvasParent, _CanvasParent);
        var scorePanelView = Instantiate(_scoreCanvasParent, _CanvasParent);
        var homePanelView = Instantiate(_homeCanvasParent, _CanvasParent);
        var buttonsPanel = Instantiate(_buttonCanvasParent, _CanvasParent);

        var menuPanelViewModel = new MenuPanelViewModel();
        var homePanelViewModel = new HomePanelViewModel();
        var scorePanelViewModel = new ScorePanelViewModel();


        _menuPanelPrefab.SetViewModel(menuPanelViewModel);
        _homePanelPrefab.SetViewModel(homePanelViewModel);
        _scorePanelPrefab.SetViewModel(scorePanelViewModel);
    }
}
