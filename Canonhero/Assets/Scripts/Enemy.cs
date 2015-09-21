using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject EnemyAttack;
    public Transform AttackPoint;

    private Animator _Anim;
    private Rigidbody2D _Rb2d;
    private bool _IsDead = false;

	void Start () {
        _Anim = GetComponent<Animator>();
        _Rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

	}

    void Dead()
    {
        GamePoints.Instance.AddPoints();
        _IsDead = true;
        _Rb2d.AddForceAtPosition(Vector2.up *  200.0f, transform.position);
        _Rb2d.gravityScale = 1.0f;
    }

    public void WeakShooted()
    {
        if(!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            Debug.Log("WeakShooted");
            Dead();
        }
    }

    public void NormalShooted()
    {
        if (!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            Debug.Log("NormalShooted");
            Dead();
        }
    }

    void Attack()
    {
        Instantiate(EnemyAttack, AttackPoint.position, AttackPoint.rotation);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.name == "Attack Area")
        {
            Attack();
        }
    }
}
