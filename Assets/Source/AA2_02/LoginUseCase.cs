using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementacion para Firebase
public class LoginUseCase : LoginRequest
{
    FirebaseLoginService firebaseLoginService;

    public LoginUseCase(FirebaseLoginService _firebaseLoginService)
    {
        firebaseLoginService = _firebaseLoginService;
    }

    public void Login()
    {
        firebaseLoginService.SignUp();
        var userData = new UserData("UserID");
        EventDispatcherService.Instance.Dispatch(userData);
    }
}