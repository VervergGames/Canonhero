using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject Ragdoll;

	void Start () {
	
	}

	void Update () {
	
	}

    public void Dead()
    {
        GameController.Instance.StopSpawning();
        GetComponent<PlayerShooting>().SetAim(false);
        Instantiate(Ragdoll, transform.position, transform.rotation);
        GameController.Instance.OpenLosePanel();
    }
}
