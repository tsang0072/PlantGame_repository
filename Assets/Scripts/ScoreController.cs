using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TMP_Text addictNum;
    // public TMP_Text plantNum;
    // public TMP_Text sugarNum;
    // public TMP_Text beanNum;
    // public TMP_Text coffeaNum;

    public TMP_Text timeNum;

    


    void Start() {
        string timeNum=GameManager.instance.Year.ToString();
        string addictNum=GameManager.instance.addictPercentage.ToString();

    }

     void Update()
    {
        timeNum.SetText("Year: " + GameManager.instance.Year);
        addictNum.SetText("Addict: " + GameManager.instance.addictPercentage+"%");
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
