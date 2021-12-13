using System.Threading.Tasks;

namespace Code.Model.UseCases.LoadScene
{
    public interface SceneLoader
    {
        Task Load(string sceneName);
    }
}