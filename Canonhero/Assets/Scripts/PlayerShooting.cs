using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerShooting : MonoBehaviour {

    public Transform SpawnPoint;
    public GameObject CanonSpawner;
    public GameObject Canonball;
    public float Delay;                         // Delay each shoot

    private float nextShoot = 0;
    private bool isAiming = false;

	void Start () {
        CanonSpawner.SetActive(false);
    }
	
	void Update () {

	}

    public void Shoot()
    {
        Instantiate(Canonball, SpawnPoint.position, SpawnPoint.rotation);
        nextShoot = Time.time + Delay;
    }

    public void StartAim()
    {
        if(canShoot() == true)
        {
            isAiming = true;
            CanonSpawner.SetActive(true);
            DOTween.Clear();
            CanonSpawner.transform.rotation = Quaternion.identity;
            CanonSpawner.transform.DOLocalRotate(new Vector3(0, 0, 60), 1).SetEase(Ease.Linear);
        }
    }

    public void ReleaseAim()
    {
        if(isAiming)
        {
            CanonSpawner.SetActive(false);
            Shoot();
            isAiming = false;
        }
    }

    bool canShoot()
    {
        if (Time.time > nextShoot)
            return true;
        else
            return false;
    }
}
