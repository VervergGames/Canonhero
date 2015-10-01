using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Chronos;

public class PlayerSkill : Singleton<PlayerSkill> {

    public float PauseTime = 2.0f;
    private GameObject SkillPanel;
    private GameObject CutInImage;
    public Sprite CutIn;
    GlobalClock GameClock;
    
    void Awake()
    {
        instance = this;
    }

	void Start () {
        SkillPanel = GameObject.FindGameObjectWithTag("SkillPanel");
        CutInImage = GameObject.FindGameObjectWithTag("CutInImage");
        SkillPanel.SetActive(false);
	    if(Timekeeper.instance.HasClock("RootGame"))
        {
            GameClock = Timekeeper.instance.Clock("RootGame");
        }
        else
        {
            Debug.LogError("RootGame Clock is not identified");
        }

        if(SkillPanel == null)
        {
            Debug.LogError("Please assign Skill Panel");
        }
	}
	
	void Update () {
	    
	}

    public void Skill()
    {
        StartCoroutine(UsingSkill());
    }

    IEnumerator UsingSkill()
    {
        GameClock.localTimeScale = 0;
        SkillPanel.SetActive(true);
        CutInImage.GetComponent<Image>().sprite = CutIn;
        yield return new WaitForSeconds(PauseTime);
        GameClock.localTimeScale = 1.0f;
        SkillPanel.SetActive(false);
    }
}
