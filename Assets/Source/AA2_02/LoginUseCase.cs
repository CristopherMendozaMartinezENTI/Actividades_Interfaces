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
        //firebaseLoginService.Login();

        var userData = new UserData("Kris");

        EventDispatcherService.Instance.Dispatch(userData);
    }
}