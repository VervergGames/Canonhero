using UnityEngine;
using System.Collections;
using Chronos;
//using VoxelBusters.NativePlugins;

public class GameController : Singleton<GameController> {

    public GameObject Player;
    public Animator Anim;
    public PlayerMovement Movement;
    public RandomSpawner Spawner;
    public GameObject MainMenuPanel;
    public GameObject ShopPanel;
    public GameObject LosePanel;

    private bool isGameStarted = false;
    private float startTime;
    private GlobalClock _GameClock;

    void Awake()
    {
        instance = this;
    }

    void Start () {
        Anim.enabled = false;
        Movement.enabled = false;
        Spawner.enabled = false;
        _GameClock = Timekeeper.instance.Clock("Game");
        //AskForReviewNow();
	}
	
	void Update () {

	}

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        Anim.enabled = true;
        Movement.enabled = true;
        Spawner.enabled = true;
        startTime = Time.time;
        isGameStarted = true;
        _GameClock.LerpTimeScale(3, 60.0f);
    }

    public void StopSpawning()
    {
        Spawner.CancelInvoke("Spawn");
    }

    public void ClearGame()
    {
        GameObject[] TempStuff = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject stuff in TempStuff)
        {
            Destroy(stuff);
        }

        GameObject[] Projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject projectile in Projectiles)
        {
            Destroy(projectile);
        }
    }

    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        ShopPanel.SetActive(false);
    }

    public void OpenLosePanel()
    {
        LosePanel.SetActive(true);
    }

    public void CloseLosePanel()
    {
        LosePanel.SetActive(false);
    }

    public void GoHome()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Revive()
    {
        AdmobManager.instance.ShowInterstitial();
        ClearGame();
        Player.SetActive(true);
        Movement.enabled = true;
        Spawner.StartSpawn();
        CloseLosePanel();
    }

    public void Retry()
    {
        ClearGame();
        GamePoints.instance.ClearPoints();
        Player.SetActive(true);
        Movement.enabled = true;
        Spawner.StartSpawn();
        CloseLosePanel();
    }

    public void DoubleCoins()
    {
        AdManager.instance.ShowRewardedAd();
    }

    public void OpenRate()
    {
        Debug.Log("Popup Rate Show");
        MobileNativeRateUs ratePopUp = new MobileNativeRateUs("Like this game?", "Please rate to support future updates!");
        ratePopUp.Start();
    }

    //private void AskForReviewNow()
    //{
    //    if (NPSettings.Utility.RateMyApp.IsEnabled)
    //    {
    //        NPBinding.Utility.RateMyApp.AskForReviewNow();
    //    }
    //}
}
