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
}
