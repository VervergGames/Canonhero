using UnityEngine;
using System.Collections;
using Chronos;
//using VoxelBusters.NativePlugins;

public class GameController : Singleton<GameController> {

    
    public GameObject MainMenuPanel;
    public GameObject ShopPanel;
    public GameObject LosePanel;
    public Transform ShopCamera;

    private GameObject Player;
    private Animator Anim;
    private PlayerMovement Movement;
    private RandomSpawner Spawner;
    private PlayerShooting Shooting;
    private CameraFollow CamFollow;

    private float startTime;
    private GlobalClock _GameClock;
    private Vector3 MainCameraPosition;

    void Awake()
    {
        instance = this;
    }

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = Player.GetComponent<Animator>();
        Movement = Player.GetComponent<PlayerMovement>();
        Shooting = Player.GetComponent<PlayerShooting>();
        CamFollow = Camera.main.GetComponent<CameraFollow>();
        Spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSpawner>();
        Anim.enabled = false;
        Movement.enabled = false;
        Spawner.enabled = false;
        _GameClock = Timekeeper.instance.Clock("Game");
        MainCameraPosition = Camera.main.transform.position;
        //AskForReviewNow();
	}
	
	void Update () {

	}

    public void StartGame()
    {
        CamFollow.enabled = true;
        MainMenuPanel.SetActive(false);
        Anim.enabled = true;
        Movement.enabled = true;
        Spawner.enabled = true;
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
        Camera.main.transform.position = ShopCamera.position;
        ShopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        Camera.main.transform.position = MainCameraPosition;
        ShopPanel.SetActive(false);
    }

    public void OpenLosePanel()
    {
        LosePanel.SetActive(true);
        //AdmobManager.instance.ShowInterstitial();
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
        AdManager.instance.ShowAd();
    }

    public void OpenRate()
    {
        Debug.Log("Popup Rate Show");
        MobileNativeRateUs ratePopUp = new MobileNativeRateUs("Like this game?", "Please rate to support future updates!");
        ratePopUp.Start();
    }

    public void PlayerAim()
    {
        Shooting.StartAim();   
    }

    public void PlayerAttack()
    {
        Shooting.ReleaseAim();
    }

    //private void AskForReviewNow()
    //{
    //    if (NPSettings.Utility.RateMyApp.IsEnabled)
    //    {
    //        NPBinding.Utility.RateMyApp.AskForReviewNow();
    //    }
    //}
}
