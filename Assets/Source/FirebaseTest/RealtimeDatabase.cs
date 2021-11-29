using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database;
using UnityEngine;

[SerializeField]
public class ScoreEntry
{
    [SerializeField]
    public int Score;
    public string Game;
    public ScoreEntry(int score, string game)
    {
        Score = score;
        Game = game;
    }
}


public class RealtimeDatabase : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            var reference = FirebaseDatabase.DefaultInstance.RootReference;
            var jsonValue = JsonUtility.ToJson(new ScoreEntry(4, "TestGame"));
            var scoreEntry = new ScoreEntry(10, "TestGame");
            reference
                .Child("scores")
                .Child(Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .SetRawJsonValueAsync(jsonValue)
                .ContinueWithOnMainThread(task =>
                {
                    if(task.IsCompleted)
                    {
                        Debug.Log("Ok");
                    }
                });
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            var reference = FirebaseDatabase.DefaultInstance.RootReference;
            var update = new Dictionary<string, object>
            {
                { $"/scores/{Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId}/Score", 45 }
            };
            reference
                .UpdateChildrenAsync(update)
                .ContinueWithOnMainThread(task =>
                {
                    if(task.IsCompleted)
                    {
                        Debug.Log("Update Ok");
                    }
                });
        }
    }
}
