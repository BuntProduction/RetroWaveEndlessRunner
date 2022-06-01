using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    InterstitialAd interstitial;
    string interstitialId;
    void Start()
    {
        RequestInterstitial();
    }

    void RequestInterstitial()
    {

#if UNITY_ANDROID
        interstitialId = "ca-app-pub-8443330060862867/2633233126";
#elif UNITY_IPHONE
        interstitialId = "ca-app-pub-8443330060862867/2634368596";
#else
        interstitialId = null;
#endif
        interstitial = new InterstitialAd(interstitialId);

        //call events
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdOpening += HandleOnAdOpened;
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        //create and ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request); //load & show the banner ad
        }
        else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            interstitial.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }

    //show the ad
    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }


    //events below
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        //do this when ad fails to load
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //do this when ad is opened
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //do this when on leaving application;
    }
}