using UnityEngine;
using System.Collections;
using Chronos;

public class PlayerSkill : MonoBehaviour {

    public float PauseTime = 2.0f;
    public GameObject SkillPanel;
    GlobalClock GameClock;

	void Start () {
	    if(Timekeeper.instance.HasClock("Game"))
        {
            GameClock = Timekeeper.instance.Clock("Game");
        }
        else
        {
            Debug.LogError("Game Clock is not identified");
        }

        if(SkillPanel == null)
        {
            Debug.LogError("Please assign Skill Panel");
        }
	}
	
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Skill();
        }
	}

    public void Skill()
    {
        StartCoroutine(UsingSkill());
    }

    IEnumerator UsingSkill()
    {
        GameClock.localTimeScale = 0;
        SkillPanel.SetActive(true);
        yield return new WaitForSeconds(PauseTime);
        GameClock.localTimeScale = 1.0f;
        SkillPanel.SetActive(false);
    }
}
