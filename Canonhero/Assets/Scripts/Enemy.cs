using UnityEngine;
using System.Collections;
using Chronos;

public class Enemy : MonoBehaviour {

    public GameObject EnemyAttack;
    public Transform AttackPoint;
    public Transform ExploisonPoint;

    private Animator _Anim;
    private Rigidbody2D _Rb2d;
    private bool _IsDead = false;
    private PlayerShooting _PlayerShooting;
    private Timeline time;

	void Start () {
        time = GetComponent<Timeline>();
        _Anim = GetComponent<Animator>();
        _Rb2d = time.GetComponent<Rigidbody2D>();
        _PlayerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
	}
	
	void Update () {

	}

    void Dead()
    {
        _IsDead = true;
        AddExplosionForce(_Rb2d, 300.0f, ExploisonPoint.position, 5.0f);
        //_Rb2d.AddForce(new Vector2(0.5f, 0.5f) * 100.0f);
        _Rb2d.gravityScale = 1.0f;
        _PlayerShooting.Reload();
    }

    public void WeakShooted()
    {
        if(!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            GamePoints.Instance.AddPoints(2);
            GameCoins.Instance.SpawnCoin(transform, "Normal");
            _PlayerShooting.Headshot();
            Debug.Log("WeakShooted");
            Dead();
        }
    }

    public void NormalShooted()
    {
        if (!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            GamePoints.Instance.AddPoints(1);
            GameCoins.Instance.SpawnCoin(transform, "Normal");
            _PlayerShooting.Bodyshot();
            Debug.Log("NormalShooted");
            Dead();
        }
    }

    public void UltimateShooted()
    {
        if(!_IsDead)
        {
            _Anim.SetTrigger("Dead");
            GamePoints.Instance.AddPoints(5);
            GameCoins.Instance.SpawnCoin(transform, "Ultimate");
        }
    }

    void Attack()
    {
        Instantiate(EnemyAttack, AttackPoint.position, AttackPoint.rotation);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.name == "Attack Area" && !_IsDead)
        {
            Attack();
        }
    }

    void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }
        body.AddForce(dir.normalized * expForce * calc);
    }
}
