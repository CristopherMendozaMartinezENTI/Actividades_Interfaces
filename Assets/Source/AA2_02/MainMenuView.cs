using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _loginButton;

    private MainMenuViewModel _model;

    public void Configure(MainMenuViewModel model)
    {
        _model = model;

        _model
            .IsVisible
            .Subscribe(isVisible => gameObject.SetActive(isVisible));

        _loginButton
            .onClick
            .AddListener(() => { _model.LoginButtonPressed.Execute(); });
    }
}