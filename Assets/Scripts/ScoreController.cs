using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TMP_Text humanNum;
    public TMP_Text plantNum;


    void Start() {
        string humanNum=GameManager.instance.humanPopulation.ToString();
        string plantNum=GameManager.instance.plantPopulation.ToString();
    }

     void Update()
    {
        humanNum.SetText("Human: " + GameManager.instance.humanPopulation);
        plantNum.SetText("Plant: " + GameManager.instance.plantPopulation);
    }

}
