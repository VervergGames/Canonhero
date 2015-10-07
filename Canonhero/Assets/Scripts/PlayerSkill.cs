using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSkill : Singleton<PlayerSkill> {

    public float PauseTime = 2.0f;
    public Sprite CutIn;

	void Start () {
	    
	}
	
	void Update () {
	    
	}

    public void Skill()
    {
        SkillManager.Instance.UseSkill(CutIn, PauseTime);
    }
}
