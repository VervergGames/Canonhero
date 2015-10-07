using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Chronos;

public class SkillManager : Singleton<SkillManager> {

    private GameObject SkillPanel;
    private GameObject CutInImage;
    GlobalClock GameClock;

    void Awake ()
    {
        instance = this;
    }

    void Start () {
        if (Timekeeper.instance.HasClock("RootGame"))
        {
            GameClock = Timekeeper.instance.Clock("RootGame");
        }
        else
        {
            Debug.LogError("RootGame Clock is not identified");
        }

        SkillPanel = GameObject.Find("Skill Panel");
        CutInImage = GameObject.FindGameObjectWithTag("CutInImage");
        SkillPanel.SetActive(false);
    }
	
	void Update () {
	
	}

    public void UseSkill(Sprite CutIn, float PauseTime)
    {
        StartCoroutine(UsingSkill(CutIn, PauseTime));
    }

    IEnumerator UsingSkill(Sprite CutIn, float PauseTime)
    {
        GameClock.localTimeScale = 0;
        SkillPanel.SetActive(true);
        CutInImage.GetComponent<Image>().sprite = CutIn;
        yield return new WaitForSeconds(PauseTime);
        GameClock.localTimeScale = 1.0f;
        SkillPanel.SetActive(false);
    }
}
