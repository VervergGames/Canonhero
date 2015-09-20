using UnityEngine;
using System.Collections;

public class ShootArea : MonoBehaviour {

    public bool isWeakPoint = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.transform.tag == "Projectile")
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            if(isWeakPoint)
            {
                enemy.NormalShooted();
            }
            else
            {
                enemy.WeakShooted();
            }
        }
    }
}
