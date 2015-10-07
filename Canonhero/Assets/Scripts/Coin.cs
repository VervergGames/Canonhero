using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public int CoinValue;
    private bool isAdded = false;

	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, 0) * 200.0f);
    }

    void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Ground" && !isAdded)
        {
            isAdded = true;
            GameCoins.Instance.AddCoin(CoinValue);
            Destroy(gameObject, 0.3f);
        }
    }
}
