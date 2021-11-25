using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class ProfileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userName;
    private ProfileViewModel _model;

    public void Configure(ProfileViewModel model)
    {
        _model = model;

        _model
            .UserName
            .Subscribe(userName => _userName.SetText(userName));
    }
}
