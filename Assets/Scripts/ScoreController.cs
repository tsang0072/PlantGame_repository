using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TMP_Text addictPer;
    public TMP_Text awarePer;

    public TMP_Text timeNum;

    public TMP_Text levelText;
    public TMP_Text pointText;


    void Start() {
        string timeNum=GameManager.instance.Year.ToString();
        string addictNum=GameManager.instance.addictPercentage.ToString();
        string point=GameManager.instance.point.ToString();
        string level=GameManager.instance.level.ToString();
        string awarePer=GameManager.instance.awareness.ToString();
    }

     void Update()
    {
        timeNum.SetText("Year: " + GameManager.instance.Year);
        addictPer.SetText("Addict: " + GameManager.instance.addictPercentage+"%");
        pointText.SetText("Point: " + GameManager.instance.point);
        levelText.SetText("Level: " + GameManager.instance.level);
        awarePer.SetText("Awareness: " + GameManager.instance.awareness);
    }

    // void NormalizePercentages()
    // {
    //     int total = sugarNum + beanNum + coffeaNum;

    //     if (total == 100)
    //         return;

    //     // Simple normalization (safe fallback)
    //     sugarPercent = Mathf.RoundToInt(sugarPercent * 100f / total);
    //     beanPercent = Mathf.RoundToInt(beanPercent * 100f / total);
    //     coffeaPercent = 100 - sugarPercent - beanPercent;
    // }

}
