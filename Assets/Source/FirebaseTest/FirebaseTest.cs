using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseTest : MonoBehaviour
{
    private Firebase.FirebaseApp app;
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
          var dependencyStatus = task.Result;
          if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
               app = Firebase.FirebaseApp.DefaultInstance;
               Debug.Log("Firebase Ok");
               Login();
               // Set a flag here to indicate whether Firebase is ready to use by your app.
          } else {
            UnityEngine.Debug.LogError(System.String.Format(
              "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
            Debug.Log("Firebase no Ok");
          }
        });
    }
    
    void Login()
    {
      Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
      auth.SignInAnonymouslyAsync().ContinueWith(task => {
        if (task.IsCanceled) {
          Debug.LogError("SignInAnonymouslyAsync was canceled.");
          return;
        }
        if (task.IsFaulted) {
          Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
          return;
        }

        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
          newUser.DisplayName, newUser.UserId);
      });
    }
}