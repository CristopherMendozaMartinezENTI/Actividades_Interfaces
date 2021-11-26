using UniRx;

public class MainMenuController
{
    private readonly MainMenuViewModel _model;
    private readonly LoginRequest _loginRequester;

    public MainMenuController(MainMenuViewModel model, LoginRequest loginRequester)
    {
        _model = model;
        _loginRequester = loginRequester;

        _model.LoginButtonPressed.Subscribe(OnLoginButtonPressed);
    }

    private void OnLoginButtonPressed(Unit _)
    {
        _loginRequester.Login();
    }
}
