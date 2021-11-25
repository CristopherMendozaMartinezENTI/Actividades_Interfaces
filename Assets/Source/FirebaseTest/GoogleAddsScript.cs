using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class GoogleAddsScript : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    
    public void Start()
    {
        string adUnitId;
        #if UNITY_ANDROID
                adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
                    adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
                    adUnitId = "unexpected_platform";
        #endif
        
        this._rewardedAd = new RewardedAd(adUnitId);
        
        // Called when an ad request has successfully loaded.
        this._rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this._rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this._rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this._rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this._rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this._rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this._rewardedAd.LoadAd(request);
        
    }

    private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        MonoBehaviour.print("HandleRewardedAdFailedToLoad event received");
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
            + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
            + amount.ToString() + " " + type);
    }
    
    private void UserChoseToWatchAd()
    {
        if (this._rewardedAd.IsLoaded()) {
            this._rewardedAd.Show();
        }
    }

    private void Update()
    {
        UserChoseToWatchAd();
    }
}