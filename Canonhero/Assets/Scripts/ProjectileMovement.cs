using UnityEngine;
using System.Collections;
using Chronos;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileMovement : MonoBehaviour {

    public float Power;
    public float DestroyDelay = 3.0f;

    private Rigidbody2D rb2d;
    private bool _AlreadyHit = false;
    private Timeline time;

	void Start () {
        time = GetComponent<Timeline>();
        rb2d = time.GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.right * Power);
	}
	
	void Update () {
        if(!_AlreadyHit)
        {
            float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (_AlreadyHit)
            return;
        _AlreadyHit = true;

        if(col.transform.tag != "Projectile")
        {
            rb2d.isKinematic = true;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent = col.transform;
            transform.localPosition = col.transform.InverseTransformPoint(col.contacts[0].point);
            GetComponentInChildren<TrailRenderer>().enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, DestroyDelay);
    }
}
