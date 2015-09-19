using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Animator _Anim;
    private Rigidbody2D _Rb2d;
    private bool _IsDead = false;

	void Start () {
        _Anim = GetComponent<Animator>();
        _Rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            Dead();
        }    }

    void Dead()
    {
        _IsDead = true;
        _Rb2d.AddForceAtPosition(Vector2.up *  200.0f, transform.position);
        _Rb2d.gravityScale = 1.0f;
    }
}
