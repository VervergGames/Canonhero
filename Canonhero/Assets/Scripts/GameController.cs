using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Animator Anim;
    public PlayerMovement Movement;
    public RandomSpawner Spawner;
    public GameObject MainMenuPanel;

	void Start () {
        Anim.enabled = false;
        Movement.enabled = false;
        Spawner.enabled = false;
	}
	
	void Update () {
	
	}

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        Anim.enabled = true;
        Movement.enabled = true;
        Spawner.enabled = true;
    }
}
