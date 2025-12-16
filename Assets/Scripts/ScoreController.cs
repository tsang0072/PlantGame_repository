using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TMP_Text humanNum;
    public TMP_Text plantNum;
    public TMP_Text sugarNum;
    public TMP_Text beanNum;
    public TMP_Text coffeaNum;

    public TMP_Text timeNum;

    


    void Start() {
        string humanNum=GameManager.instance.humanPopulation.ToString();
        string plantNum=GameManager.instance.plantPopulation.ToString();
        string sugarNum=GameManager.instance.sugarPercent.ToString();
        string beanNum=GameManager.instance.beanPercent.ToString();
        string coffeaNum=GameManager.instance.coffeaPercent.ToString();
        string timeNum=GameManager.instance.timer.ToString();

    }

     void Update()
    {
        humanNum.SetText("Human: " + GameManager.instance.humanPopulation);
        plantNum.SetText("Plant: " + GameManager.instance.plantPopulation);
        sugarNum.SetText("Sugar: " + GameManager.instance.sugarPercent +" %");
        beanNum.SetText("Bean: " + GameManager.instance.beanPercent +" %");
        coffeaNum.SetText("Coffea: " + GameManager.instance.coffeaPercent +" %");
        timeNum.SetText("Time: " + GameManager.instance.timer);
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
