using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AutoMoveTo : MonoBehaviour {

    private Transform _Target;
    public float Speed;
    private bool _AlreadyHit = false;

    void Start () {
        _Target = GameObject.Find("Player").transform;
	}
	
	void Update () {
        transform.DOMove(_Target.position, Speed, false).SetEase(Ease.Linear);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (_AlreadyHit)
            return;
        _AlreadyHit = true;

        if (col.transform.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
