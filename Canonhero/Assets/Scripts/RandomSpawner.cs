using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {

    public GameObject Object;
    public Transform SpawnPoint;
    public float Interval;
    public Vector2 OffsetMin;
    public Vector2 OffsetMax;

	void Start () {
        InvokeRepeating("Spawn", 1.0f, Interval);
	}
	
	void Update () {
	
	}

    void Spawn()
    {
        float xPos = Random.Range(OffsetMin.x, OffsetMax.x);
        float yPos = Random.Range(OffsetMin.y, OffsetMax.y);
        Vector3 nextSpawn = SpawnPoint.position + new Vector3(xPos, yPos);
        Instantiate(Object, nextSpawn, SpawnPoint.rotation);
    }
}
