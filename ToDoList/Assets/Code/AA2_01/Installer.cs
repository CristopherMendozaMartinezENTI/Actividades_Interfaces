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

    // Start is called before the first frame update
    void Awake()
    {
        var settingPanelView = Instantiate(_settingCanvasParent, _CanvasParent);
        var scorePanelView = Instantiate(_scoreCanvasParent, _CanvasParent);
        var homePanelView = Instantiate(_homeCanvasParent, _CanvasParent);
        var buttonsPanel = Instantiate(_buttonCanvasParent, _CanvasParent);
    }
}
