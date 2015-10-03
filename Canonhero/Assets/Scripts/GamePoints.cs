using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePoints : Singleton<GamePoints> {

    public Text PointsText;
    private int CurrentPoints;

    void Awake()
    {
        instance = this;
    }

    void Start () {
        CurrentPoints = 0;
        UpdatePointText();
	}

    public int GetPoints()
    {
        return CurrentPoints;
    }

    public void ClearPoints()
    {
        CurrentPoints = 0;
        UpdatePointText();
    }

    public void AddPoints(int value)
    {
        CurrentPoints += value;
        UpdatePointText();
    }

    void UpdatePointText()
    {
        PointsText.text = CurrentPoints.ToString();
    }
}
