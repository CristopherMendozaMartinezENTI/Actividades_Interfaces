using UniRx;

public class MainMenuController
{
    private readonly MainMenuViewModel _model;
    private readonly LoginRequester _loginRequester;

    public MainMenuController(MainMenuViewModel model, LoginRequester loginRequester)
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
