using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AimProjectile : MonoBehaviour {

    public Transform target;
    public bool auto = false;

	void Start () {
        if(auto)
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(target.DOLocalRotate(new Vector3(0, 0, 60), 1).SetEase(Ease.Linear));
            mySequence.Append(target.DOLocalRotate(new Vector3(0, 0, 0), 1).SetEase(Ease.Linear));
            mySequence.SetLoops(-1);
        }    
    }
	
	void Update () {
        
	}

    public void StartAiming()
    {
        
    }
}
