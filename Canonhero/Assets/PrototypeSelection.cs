using UnityEngine;
using System.Collections;

public class PrototypeSelection : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void GotoScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
