using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform Target;
    public Vector3 Offset;

	void Start () {
	
	}
	
	void Update () {
        transform.position = new Vector3(Target.position.x + Offset.x, transform.position.y + Offset.y, transform.position.z + Offset.z);
	}
}
