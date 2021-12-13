using System.Threading.Tasks;

namespace Code.Model.UseCases.Authenticate
{
    public interface Authenticator
    {
        Task Authenticate();
    }
}