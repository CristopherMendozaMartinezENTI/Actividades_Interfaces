using UnityEngine;
using UniRx;
using TMPro;

public class ProfileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userId;
    private ProfileViewModel _model;

    public void Configure(ProfileViewModel model)
    {
        _model = model;

        _model
            .UserId
            .Subscribe(userName => _userId.SetText(userName));
    }
}
