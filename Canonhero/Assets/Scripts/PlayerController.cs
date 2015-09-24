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
        Instantiate(Ragdoll, transform.position, transform.rotation);
        GameController.Instance.OpenLosePanel();
    }
}
