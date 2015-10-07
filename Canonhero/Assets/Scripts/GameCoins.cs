using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameCoins : Singleton<GameCoins> {

    public GameObject[] coins;
    public Text CoinText;
    private int CurrentCoins;

    void Awake ()
    {
        instance = this;
    }

	void Start () {
        CurrentCoins = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinText();
    }

	void Update () {
	
	}

    public int GetCoin()
    {
        return CurrentCoins;
    }

    public void AddCoin(int value)
    {
        CurrentCoins += value;
        PlayerPrefs.SetInt("Coins", CurrentCoins);
        UpdateCoinText();
    }

    public void SpawnCoin(Transform pos, string type)
    {
        if(type == "Normal")
        {
            Instantiate(coins[0], pos.position, pos.rotation);
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                int j = Random.Range(0, coins.Length);
                Instantiate(coins[j], pos.position, pos.rotation);
            }
        }
    }

    void UpdateCoinText()
    {
        CoinText.text = CurrentCoins.ToString();
    }
}
