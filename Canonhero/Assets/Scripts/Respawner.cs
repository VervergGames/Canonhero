using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

    public GameObject TargetCollide;
    public InfinitySpawner TheSpawner;

	void Start () {

	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == TargetCollide.tag)
        {
            TheSpawner.SpawnNext();
        }
    }
}
