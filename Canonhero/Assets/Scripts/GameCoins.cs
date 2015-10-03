using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameCoins : Singleton<GameCoins> {

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
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        CoinText.text = CurrentCoins.ToString();
    }
}
