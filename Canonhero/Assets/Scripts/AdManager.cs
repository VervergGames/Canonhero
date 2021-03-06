﻿using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : Singleton<AdManager> 
{
    //[SerializeField] string gameID = "33675";

    void Awake()
    {
        instance = this;
    }

    //public void ShowAd(string zone = "")
    //{
    //    Debug.Log("Show Ad");
    //    #if UNITY_EDITOR
    //        StartCoroutine(WaitForAd ());
    //    #endif

    //    if (string.Equals (zone, ""))
    //        zone = null;

    //    ShowOptions options = new ShowOptions ();
    //    options.resultCallback = AdCallbackhandler;

    //    if (Advertisement.isReady (zone))
    //        Advertisement.Show (zone, options);
    //}

    //void AdCallbackhandler (ShowResult result)
    //{
    //    switch(result)
    //    {
    //    case ShowResult.Finished:
    //        Debug.Log ("Ad Finished. Rewarding player...");
    //        break;
    //    case ShowResult.Skipped:
    //        Debug.Log ("Ad skipped. Son, I am dissapointed in you");
    //        break;
    //    case ShowResult.Failed:
    //        Debug.Log("I swear this has never happened to me before");
    //        break;
    //    }
    //}

    //IEnumerator WaitForAd()
    //{
    //    Debug.Log("Wait for Ad");
    //    float currentTimeScale = Time.timeScale;
    //    Time.timeScale = 0f;
    //    yield return null;

    //    while (Advertisement.isShowing)
    //        yield return null;

    //    Time.timeScale = currentTimeScale;
    //}

    void Start()
    {
        ShowAd();
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}