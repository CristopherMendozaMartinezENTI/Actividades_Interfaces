using System;
using System.Collections.Generic;
using Code.Model.Repositories.User;
using Code.Model.Services;
using Code.Model.Services.Authentication;
using Code.Model.Services.Database;
using Code.Model.Services.SceneHandler;
using Code.Model.UseCases.Authenticate;
using Code.Model.UseCases.InitializeNewUser;
using Code.Model.UseCases.LoadInitialData;
using Code.Model.UseCases.LoadScene;
using Code.Model.UseCases.LoadUserData;
using Code.Utils;
using UnityEngine;

namespace Code
{
    public class InitInstaller : MonoBehaviour
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        private LoadInitialDataUseCase _loadInitialDataUseCase;

        private void Awake()
        {
            var sceneHandlerService = new UnitySceneHandler();
            var userRepository = new UserRepository();
            var databaseService = new FirebaseService();
            var eventDispatcherService = new EventDispatcherService();
            var firebaseAuthenticationService = new FirebaseAuthenticationService();

            ServiceLocator.Instance.RegisterService<SceneHandlerService>(sceneHandlerService);
            ServiceLocator.Instance.RegisterService<UserDataAccess>(userRepository);
            ServiceLocator.Instance.RegisterService<DatabaseService>(databaseService);
            ServiceLocator.Instance.RegisterService<IEventDispatcherService>(eventDispatcherService);
            ServiceLocator.Instance.RegisterService<AuthenticationService>(firebaseAuthenticationService);


            var authenticateUseCase = new AuthenticateUseCase(firebaseAuthenticationService, eventDispatcherService);
            var loadSceneUseCase = new LoadSceneUseCase(sceneHandlerService);
            var initializeNewUserUseCase =
                new InitializeNewUserUseCase(databaseService,
                    userRepository,
                    firebaseAuthenticationService);
            var loadUserDataUseCase = new LoadUserDataUseCase(initializeNewUserUseCase,
                databaseService,
                userRepository,
                firebaseAuthenticationService);
            _loadInitialDataUseCase =
                new LoadInitialDataUseCase(loadSceneUseCase, authenticateUseCase, loadUserDataUseCase);
        }

        private void Start()
        {
            _loadInitialDataUseCase.Init();
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}