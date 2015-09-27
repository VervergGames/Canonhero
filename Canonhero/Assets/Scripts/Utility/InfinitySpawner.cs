using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfinitySpawner : MonoBehaviour {

    public GameObject Object;
    public Sprite[] Sprites;
    public int MaxObject = 3;

    private GameObject _CurrentObject;
    private List<GameObject> _ObjectPools = new List<GameObject>();
    private int _PoolIndex = 0;

	void Start () {
        _CurrentObject = Object;
        AssignRandomSprites(_CurrentObject);
        _ObjectPools.Add(_CurrentObject);
        for (int i = 0; i < MaxObject - 1; i++)
        {
            SpawnNext();
        }
	}

    public void SpawnNext()
    {
        Vector3 nextPost = new Vector3(_CurrentObject.transform.position.x + _CurrentObject.GetComponent<BoxCollider2D>().size.x, _CurrentObject.transform.position.y, _CurrentObject.transform.position.z);
        if(_ObjectPools.Count == MaxObject)
        {
            _CurrentObject = _ObjectPools[_PoolIndex];
            _CurrentObject.transform.position = nextPost;
            NextPool();
        }
        else
        {
            _CurrentObject = Instantiate(Object, nextPost, Object.transform.rotation) as GameObject;
            _ObjectPools.Add(_CurrentObject);
        }

        AssignRandomSprites(_CurrentObject);
    }

    void NextPool()
    {
        _PoolIndex++;
        if(_PoolIndex >= MaxObject)
        {
            _PoolIndex = 0;
        }
    }

    void AssignRandomSprites(GameObject CurrentObject)
    {
        CurrentObject.GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];
    }
}
