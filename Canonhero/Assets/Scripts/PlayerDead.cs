using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

    public float Force = 7.0f;
    public float Radius = 3.0f;
    public Transform ExplosionPoint;
    private Rigidbody2D _Rb2d;

	void Start () {
        _Rb2d = GetComponent<Rigidbody2D>();
        Dead();
	}

    void Dead()
    {
        AddExplosionForce(_Rb2d, Force * 100.0f, ExplosionPoint.position, Radius);
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