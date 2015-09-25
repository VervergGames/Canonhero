using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioSource BGM;
    public AudioSource SFX;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void ToggleBGM()
    {
        BGM.mute = !BGM.mute;
    }

    public void ToggleSFX()
    {
        SFX.mute = !SFX.mute;
    }
}
