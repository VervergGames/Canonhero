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
        Enemy enemy = GetComponentInParent<Enemy>();
        if (col.transform.tag == "Projectile")
        {
            if(isWeakPoint)
            {
                enemy.NormalShooted();
            }
            else
            {
                enemy.WeakShooted();
            }
        }
        else if(col.transform.tag == "Ultimate Projectile")
        {
            enemy.UltimateShooted();
        }
    }
}
