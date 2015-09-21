using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AutoMoveTo : MonoBehaviour {

    private Transform _Target;
    public float Speed;

	void Start () {
        _Target = GameObject.Find("Player").transform;
	}
	
	void Update () {
        transform.DOMove(_Target.position, Speed, false).SetEase(Ease.Linear);
	}
}
