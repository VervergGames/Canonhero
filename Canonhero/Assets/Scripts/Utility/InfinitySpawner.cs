using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfinitySpawner : Singleton<InfinitySpawner> {

    public GameObject Object;
    public int StartSpawn = 1;
    public int MaxObject = 3;

    private GameObject _CurrentObject;
    private List<GameObject> _ObjectPools = new List<GameObject>();
    private int _PoolIndex = 0;

    void Awake()
    {
        instance = this;
    }

	void Start () {
        _CurrentObject = Object;
        _ObjectPools.Add(_CurrentObject);
        for (int i = 0; i < StartSpawn; i++)
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
    }

    void NextPool()
    {
        _PoolIndex++;
        if(_PoolIndex >= MaxObject)
        {
            _PoolIndex = 0;
        }
    }
}
