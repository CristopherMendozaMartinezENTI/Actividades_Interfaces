using System.Threading.Tasks;
using Code.Model.Repositories.User;
using Code.Model.Services;
using Code.Model.Services.Authentication;
using Code.Model.Services.Database;
using Code.Model.UseCases.Authenticate;
using Code.Utils;

namespace Code.Model.UseCases.InitializeNewUser
{
    public class InitializeNewUserUseCase : UserInitializer
    {
        private readonly DatabaseService _databaseService;
        private readonly UserDataAccess _userDataAccess;
        private readonly AuthenticationService _authenticationService;

        public InitializeNewUserUseCase(DatabaseService databaseService,
            UserDataAccess userDataAccess,
            AuthenticationService authenticationService)
        {
            _databaseService = databaseService;
            _userDataAccess = userDataAccess;
            _authenticationService = authenticationService;
        }
        
        public async Task Init()
        {
            var userId = _authenticationService.UserId;
            var name = "RandomName"; // TODO: obtain it from a service (random from a list?)

            var userEntity = new UserEntity(userId, name);
            _userDataAccess.SetLocalUser(userEntity);

            var userDto = new UserDto(userId, name);
            await _databaseService.Save(userDto, $"users/{userId}");
        }
    }
}