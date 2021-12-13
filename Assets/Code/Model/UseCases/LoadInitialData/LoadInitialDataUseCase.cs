using Code.Model.UseCases.Authenticate;
using Code.Model.UseCases.LoadScene;
using Code.Model.UseCases.LoadUserData;

namespace Code.Model.UseCases.LoadInitialData
{
    public class LoadInitialDataUseCase
    {
        private readonly SceneLoader _sceneLoader;
        private readonly Authenticator _authenticator;
        private readonly UserDataLoader _userDataLoader;

        public LoadInitialDataUseCase(SceneLoader sceneLoader,
            Authenticator authenticator,
            UserDataLoader userDataLoader)
        {
            _sceneLoader = sceneLoader;
            _authenticator = authenticator;
            _userDataLoader = userDataLoader;
        }

        public async void Init()
        {
            await _authenticator.Authenticate();
            await _userDataLoader.Load();
            await _sceneLoader.Load("Menu");
        }
    }
}