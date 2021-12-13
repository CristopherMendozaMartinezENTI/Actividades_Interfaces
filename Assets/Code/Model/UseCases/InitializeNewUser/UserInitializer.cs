using System.Threading.Tasks;

namespace Code.Model.UseCases.InitializeNewUser
{
    public interface UserInitializer
    {
        Task Init();
    }
}