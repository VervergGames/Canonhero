using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdmobManager : Singleton<AdmobManager> {

    public string BannerId;
    public string InterstitialId;
    private BannerView banner;
    private InterstitialAd interstitial;

    void Awake ()
    {
        instance = this;
    }

	void Start () {
        RequestBanner();
        RequestInterstitial();
        ShowBanner();
	}

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        banner = new BannerView(BannerId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        banner.LoadAd(request);
    }

    public void ShowBanner()
    {
        banner.Show();
    }

    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(InterstitialId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
        else
            Debug.Log("Interstitial not loaded");
    }
}
