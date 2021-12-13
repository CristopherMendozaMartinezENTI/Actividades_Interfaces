using System.Threading.Tasks;
using Code.Model.Repositories.User;
using Code.Model.Services;
using Code.Model.Services.Authentication;
using Code.Model.Services.Database;
using Code.Model.UseCases.InitializeNewUser;

namespace Code.Model.UseCases.LoadUserData
{
    public class LoadUserDataUseCase : UserDataLoader
    {
        private readonly UserInitializer _userInitializer;
        private readonly DatabaseService _databaseService;
        private readonly UserDataAccess _userDataAccess;
        private readonly AuthenticationService _authenticationService;

        public LoadUserDataUseCase(UserInitializer userInitializer,
            DatabaseService databaseService,
            UserDataAccess userDataAccess,
            AuthenticationService authenticationService)
        {
            _userInitializer = userInitializer;
            _databaseService = databaseService;
            _userDataAccess = userDataAccess;
            _authenticationService = authenticationService;
        }

        public async Task Load()
        {
            var userId = _authenticationService.UserId;
            var isNewUser = !await _databaseService.ExistKey($"users/{userId}");
            if (isNewUser)
            {
                await _userInitializer.Init();
                return;
            }

            var userDto = await _databaseService.Load<UserDto>($"users/{userId}");
            var userEntity = new UserEntity(userDto.UserId, userDto.Name);
            _userDataAccess.SetLocalUser(userEntity);
        }
    }
}