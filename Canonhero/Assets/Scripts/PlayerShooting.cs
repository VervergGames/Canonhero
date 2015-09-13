using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerShooting : MonoBehaviour {

    public Transform SpawnPoint;
    public GameObject CanonSpawner;
    public GameObject Canonball;

	void Start () {
        //CanonSpawner.SetActive(false);
    }
	
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        Instantiate(Canonball, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void StartAim()
    {
        CanonSpawner.SetActive(true);
        DOTween.Clear();
        CanonSpawner.transform.rotation = Quaternion.identity;
        CanonSpawner.transform.DOLocalRotate(new Vector3(0, 0, 60), 1).SetEase(Ease.Linear);
    }

    public void ReleaseAim()
    {
        CanonSpawner.SetActive(false);
        Shoot();
    }
}
