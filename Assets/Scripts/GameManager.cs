using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game State")]
    public bool gameRunning = false;

    [Header("Population")]
    public int totalPopulation=700000000;
    public int addictNum=0;
    public int addictPercentage=0;

    [Header("Addiction")]
    public float spreadRate = 0.001f; 

    public float Year;
    bool isTicking=false;



    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (!gameRunning)
            return;
       

        if(!isTicking){
            StartCoroutine(FiveSec());
            }
            
        AddictGrowth(Year);

        
    }
    public void StartGame()
    {
        //totalPopulation = country.totalPopulation;
        addictNum=100;
        gameRunning = true;

    }

    public void AddictGrowth(float dt)
    {
        float remaining = totalPopulation - addictNum;
        if (remaining <= 0f) return;

        float tem= spreadRate * remaining * dt;
        addictNum = Convert.ToInt32(tem);

       addictPercentage= addictNum / totalPopulation;
    //    float temp= addictNum/totalPopulation;
    //     addictPercentage = Convert.ToInt32(temp);
    }

    // =========================
    // CORE LOOP
    // =========================

    void Tick()
    {
        
    }

    public void StopGame()
    {
        gameRunning=false;
    }

    public void ContinueGame()
    {
        gameRunning=true;
    }


     IEnumerator FiveSec()
 {
        isTicking=true;
        yield return new WaitForSeconds(3);
        Year+=1;
        isTicking=false;
 }
}
