using System.Threading.Tasks;
using Code.Model.Services.SceneHandler;

namespace Code.Model.UseCases.LoadScene
{
    public class LoadSceneUseCase : SceneLoader
    {
        private readonly SceneHandlerService _sceneHandlerService;

        public LoadSceneUseCase(SceneHandlerService sceneHandlerService)
        {
            _sceneHandlerService = sceneHandlerService;
        }
        
        public async Task Load(string sceneName)
        {
            await _sceneHandlerService.LoadScene(sceneName);
        }
    }
}