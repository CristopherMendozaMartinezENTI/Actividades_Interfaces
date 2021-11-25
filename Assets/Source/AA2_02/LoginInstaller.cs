using System;
using System.Collections.Generic;
using UnityEngine;

public class LoginInstaller : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private ProfileView _profileView;
        
    private void Awake()
    {
        var mainMenuViewModel = new MainMenuViewModel();
        _mainMenuView.Configure(mainMenuViewModel);
        var profileViewModel = new ProfileViewModel();
        _profileView.Configure(profileViewModel);
        var loginUseCase = new LoginUseCase();
        var mainMenuPresenter = new MainMenuPresenter(mainMenuViewModel);
        var mainMenuController = new MainMenuController(mainMenuViewModel, loginUseCase);
        new ProfilePresenter(profileViewModel);
    }
}