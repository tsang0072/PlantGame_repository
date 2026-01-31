using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game State")]
    public bool gameRunning = false;

    [Header("Population")]
    public int totalPopulation=7000000;
    public int addictNum=0;
    public int addictPercentage=0;

    [Header("Addiction")]
    public float spreadRate = 0.001f; 

    [Header("Evolution")]
    public int point;
    public int level;

    [Header("Awareness")]
    public int awareness;  

    public float Year;
    bool isTicking=false;
    bool isTicking2=false;
    private int lastAddictedCheckpoint;



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
            
        //AddictGrowth(Time.deltaTime);
        //CheckEvolutionProgress();

        if (addictNum >= totalPopulation)
        {
            gameRunning=false;
            Time.timeScale=0;
        }
        if (Year!=0&&addictNum <= 0)
        {
            addictNum=0;
            gameRunning=false;
            Time.timeScale=0;
        }

        if(!isTicking2){
            StartCoroutine(OneMin());
            }
    }
    public void StartGame()
    {
        //totalPopulation = country.totalPopulation;
        addictNum=100;
        gameRunning = true;
        point = 0;
        level = 0;
        lastAddictedCheckpoint = 0;
        awareness=0;

    }

    public void AddictGrowth(float dt)
    {
        float remaining = totalPopulation - addictNum;
        if (remaining <= 0) return;

        if (level > 5&&level<=10)
        {
            addictNum+=5000;
        }else if (level > 10&&level<=15)
        {
            addictNum+=10000;
        }else if (level > 15)
        {
            addictNum+=100000;
        }
        float growth = spreadRate * remaining * dt;

        addictNum += Mathf.RoundToInt(growth);
        addictNum = Mathf.Clamp(addictNum, 0, totalPopulation);

        addictPercentage = addictNum * 100 / totalPopulation;


    }

    void UpdateAwareness()
    {
    if(awareness==100) return;

    if (spreadRate>0.005&&spreadRate<0.02)
    {
        awareness += 1;
    }
    else if (spreadRate > 0.02 && spreadRate < 0.05)
    {
            awareness += 5;
    }
    else if (spreadRate > 0.05)
    {
            awareness += 10;
    }
    if (awareness > 100)
        {
            awareness=100;
        }


    }

    public void reduceAddict()
    {
        if (awareness > 10&&awareness < 40)
        {
            spreadRate-=0.0001f;
        }else if(awareness >= 40&&awareness < 80)
        {
            spreadRate-=0.0003f;
        }
        else if(awareness > 80&&awareness <= 100)
        {
            spreadRate-=0.005f;
        }
        
    }

    
    public void PhysicLevelUp()
    {
        if (point >= 3)
        {
            point-=3;
            level++;
            spreadRate += 0.005f;

        }
    }
     public void MentalLevelUp()
    {
        if (point >= 2&&awareness>=10)
        {
            point-=2;
            
            awareness-=10;;

        }
    }

    void CheckEvolutionProgress()
    {
        int checkpointsPassed = addictNum / 10000;

        if (checkpointsPassed > lastAddictedCheckpoint)
        {
            point += 1;
            lastAddictedCheckpoint = checkpointsPassed;
        }
    }
    
    public void WinGame()
    {
        UIManager.instance.WinBoard();
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
        Year += 1;

        AddictGrowth(1f);          // ONE tick
        CheckEvolutionProgress();  // ONE chance to gain point
        UpdateAwareness();
        isTicking=false;
 }

 IEnumerator OneMin()
    {
        isTicking2=true;
        yield return new WaitForSeconds(5);
        reduceAddict();
        isTicking2=false;
    }
}
