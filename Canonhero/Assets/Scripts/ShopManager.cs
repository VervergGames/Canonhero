using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

    [System.Serializable]
    public class Hero
    {
        public string HeroName;
        public GameObject Preview;
        public GameObject Player;
    }

    public Hero[] Heroes;
    public Transform CharPreview;
    public Transform HeroPos;

    private GameObject[] HeroPlayers;
    private GameObject[] Previews;
    private int CurrentHero;

	void Start () {
        Previews = new GameObject[Heroes.Length];
        HeroPlayers = new GameObject[Heroes.Length];
        CurrentHero = PlayerPrefs.GetInt("Hero", 0);
        InitiatePreviews();
        ChooseCharacter(CurrentHero);
	}
	
	void Update () {
	
	}

    void InitiatePreviews()
    {
        for(int i = 0; i < Heroes.Length; i++)
        {
            HeroPlayers[i] = Instantiate(Heroes[i].Player, HeroPos.position, HeroPos.rotation) as GameObject;
            Previews[i] = Instantiate(Heroes[i].Preview, CharPreview.position, CharPreview.rotation) as GameObject;
        }
    }

    public void ChooseCharacter(int i)
    {
        foreach(GameObject p in Previews)
        {
            p.SetActive(false);
        }

        Previews[i].SetActive(true);
        CurrentHero = i;
        PlayerPrefs.SetInt("Hero", CurrentHero);
        ChooseHero();
    }

    void ChooseHero()
    {
        foreach (GameObject p in HeroPlayers)
        {
            p.SetActive(false);
        }
        HeroPlayers[CurrentHero].SetActive(true);
        GameController.Instance.UpdatePlayer();
    }
}
