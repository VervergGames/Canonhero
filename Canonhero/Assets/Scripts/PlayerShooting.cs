using UnityEngine;
using System.Collections;
using DG.Tweening;
using Chronos;

public class PlayerShooting : MonoBehaviour {

    [System.Serializable]
    public class AimingObject
    {
        public GameObject Object;
        public float MaxRotation;
    }

    public Transform SpawnPoint;
    public GameObject Aimer;
    public GameObject NormalAttack;
    public GameObject UltimateAttack;
    public float Delay;                         // Delay each shoot

    public AimingObject[] Aimings;

    private float nextShoot = 0;
    private bool isAiming = false;
    private bool isUltimate = false;
    private int UltimateCount = 0;

	void Start () {
        Aimer.SetActive(false);
    }
	
	void Update () {
        
	}

    public void Shoot()
    {
        if(isUltimate)
        {
            PlayerSkill.Instance.Skill();
            Instantiate(UltimateAttack, SpawnPoint.position, SpawnPoint.rotation);
            isUltimate = false;
        }
        else
        {
            Instantiate(NormalAttack, SpawnPoint.position, SpawnPoint.rotation);
        }
        nextShoot = Time.time + Delay;
    }

    public void StartAim()
    {
        if(canShoot() == true)
        {
            isAiming = true;
            Aimer.SetActive(true);
            //Aimer.transform.rotation = Quaternion.identity;
            //Aimer.transform.DOLocalRotate(new Vector3(0, 0, 60), 1).SetEase(Ease.Linear);
            foreach(AimingObject obj in Aimings)
            {
                obj.Object.transform.DOLocalRotate(new Vector3(0, 0, obj.MaxRotation), 1).SetEase(Ease.Linear);
            }
        }
    }

    public void ReleaseAim()
    {
        if(isAiming)
        {
            Aimer.SetActive(false);
            Shoot();
            isAiming = false;
            DOTween.Clear();
            ResetAimers();
        }
    }

    bool canShoot()
    {
        if (Time.time > nextShoot)
            return true;
        else
            return false;
    }

    public void Reload()
    {
        nextShoot = 0;
    }

    public void SetAim(bool aiming)
    {
        isAiming = aiming;
    }

    void ResetAimers()
    {
        foreach (AimingObject obj in Aimings)
        {
            obj.Object.transform.rotation = Quaternion.identity;
        }
    }

    public void Headshot()
    {
        UltimateCount++;
        if(UltimateCount == 3)
        {
            isUltimate = true;
            UltimateCount = 0;
        }
    }

    public void Bodyshot()
    {
        UltimateCount = 0;
    }
}
