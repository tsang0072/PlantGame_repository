using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    // public float awarenessPenalty = 0.5f;
    // public float awarenessDecay = 0.01f;
    
    // public float fastGrowthThreshold = 0.02f; // 2% per tick
    // public float spikeThreshold = 50000f;     // +50k in one tick

    public float Year;
    bool isTicking=false;
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
            
        AddictGrowth(Year);
        CheckEvolutionProgress();

        
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
        if (remaining <= 0f) return;

        float tem= spreadRate * remaining * dt;
        addictNum = Convert.ToInt32(tem);

        addictPercentage= 100*addictNum / totalPopulation;

        UpdateAwareness();

    }

    void UpdateAwareness()
    {


    if (spreadRate>0.005&&spreadRate<0.02)
    {
        awareness += 1;
    }
    else if (spreadRate > 0.02 && spreadRate < 0.05)
    {
            awareness += 2;
    }
    else if (spreadRate > 0.05)
    {
            awareness += 5;
    }else if (spreadRate < 0.02)
        {
            awareness=0;
        }


    }

    
    public void LevelUp()
    {
        if (point >= 3)
        {
            point-=3;
            level++;
            spreadRate += 0.005f;

            int addictedInt = Mathf.FloorToInt(addictNum);
            int checkpointsPassed = addictedInt / 10000;
            lastAddictedCheckpoint = checkpointsPassed;
        }
    }

    void CheckEvolutionProgress()
{
    int addictedInt = Mathf.FloorToInt(addictNum);

    int checkpointsPassed = addictedInt / 10000;

    int newPoints = checkpointsPassed - lastAddictedCheckpoint;

    if (newPoints > 0)
    {
        point += 1;
        lastAddictedCheckpoint = checkpointsPassed;

    }
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
