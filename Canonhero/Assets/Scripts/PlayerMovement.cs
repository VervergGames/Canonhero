using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour {

    public float Speed;

	void Start () {
	
	}
	
	void Update () {
        transform.DOMoveX(transform.position.x + Speed, 1f);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Ground")
        {
            InfinitySpawner.Instance.SpawnNext();
        }
    }
}
