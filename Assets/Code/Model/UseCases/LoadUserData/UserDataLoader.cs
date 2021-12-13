using System.Threading.Tasks;

namespace Code.Model.UseCases.LoadUserData
{
    public interface UserDataLoader
    {
        Task Load();
    }
}