using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public GameObject NextObstacle;
    public float minHeight;
    public float maxHeight;
    private GameObject enemy;

	void Start () {
        enemy = GetComponentInChildren<Enemy>().gameObject;
        float height = Random.Range(minHeight, maxHeight);
        Debug.Log(height);
        enemy.transform.position = new Vector3(enemy.transform.position.x, height, enemy.transform.position.z);
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Destroyer")
        {
            GameObject NewObstacle = Instantiate(Resources.Load("Obstacle", typeof(GameObject)), NextObstacle.transform.position + new Vector3(7.5f, 0, 0), Quaternion.identity) as GameObject;
            NextObstacle.GetComponent<Obstacle>().NextObstacle = NewObstacle;
        }
    }
}
