using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text addictPer;
    public TMP_Text awarePer;

    public TMP_Text timeNum;

    public TMP_Text levelText;
    public TMP_Text pointText;
    public GameObject winBoard;


    void Awake()
    {
        instance = this;
    }
    
    void Start() {
        string timeNum=GameManager.instance.Year.ToString();
        string addictNum=GameManager.instance.addictPercentage.ToString();
        string point=GameManager.instance.point.ToString();
        string level=GameManager.instance.level.ToString();
        string awarePer=GameManager.instance.awareness.ToString();

        winBoard.SetActive(false);
    }

     void Update()
    {
        timeNum.SetText("Year: " + GameManager.instance.Year);
        addictPer.SetText("Addict: " + GameManager.instance.addictPercentage+"%");
        pointText.SetText("Point: " + GameManager.instance.point);
        levelText.SetText("Level: " + GameManager.instance.level);
        awarePer.SetText("Awareness: " + GameManager.instance.awareness);

        
    }

    public void WinBoard()
    {
        winBoard.SetActive(true);
        Debug.Log("Win");
    }

}
