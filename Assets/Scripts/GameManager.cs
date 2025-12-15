using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Time")]
    public float gameDuration = 1200f; // 20 minutes
    private float timer;

    [Header("Macro Data")]
    public int humanPopulation = 4000000;
    public int plantPopulation = 50;

    [Header("Substances")]
    public float sugar = 40f;
    public float bean = 10f;
    public float coffea = 0f;

    [Header("Rates")]
    //public float sugarConsumptionPerHuman = 0.000001f;
    public int plantGrowth = 2;
    public float coffeaBoost = 0.5f;
    public float coffeaDeathThreshold = 5f;

    [Header("Growth Control")]
    //public float humanGrowthRate = 0.001f;
    public float coffeaFatigue = 0f;
    public float coffeaFatigueIncrease = 0.05f;
    public float coffeaFatigueRecovery = 0.02f;

    [Header("Plant Milestone")]
    public int plantMilestone = 1000000;

    private float tickTimer;
    public float tickInterval = 1f; // 1 second per turn

    
    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        timer = gameDuration;
    }

    void Update()
    {
        if (timer <= 0)
        {
            EndGame();
            return;
        }

        timer -= Time.deltaTime;
        tickTimer += Time.deltaTime;

        if (tickTimer >= tickInterval)
        {
            Tick();
            tickTimer = 0;
        }
    }

    void Tick()
    {

        if (sugar < 0)
        {
            humanPopulation -= 10000;
            sugar = 0;
        }

        //Plant growth
        // float growthMultiplier = 1 + coffea * coffeaBoost;
        // float fatiguePenalty = Mathf.Clamp01(coffeaFatigue);

        // int plantGrowth = Mathf.RoundToInt(
        // basePlantGrowth * growthMultiplier * (1 - fatiguePenalty)
        // );

        plantPopulation += plantGrowth*plantGrowth;

        //Human growth (rough trend)
        if(humanPopulation>1000000000)
            plantGrowth=2;
        else if(humanPopulation>100000000)
            plantGrowth=10;
        else if(humanPopulation>10000000)
            plantGrowth=5;
        else if(humanPopulation>5000000)
            plantGrowth=2;       
        
        if (plantPopulation > 10000)
            humanPopulation += 1000000;
        else if (plantPopulation > 1000)
            humanPopulation += 100000;
        else if (plantPopulation > 100)
            humanPopulation += 10000;
        else
            humanPopulation += 500;

        //Coffea overdose
        if (coffea > 0)
        {

            coffeaFatigue += coffeaFatigueIncrease * coffea;
        }
        else
        {
            coffeaFatigue -= coffeaFatigueRecovery;
        }

        coffeaFatigue = Mathf.Clamp01(coffeaFatigue);

        coffeaFatigue -= bean * 0.02f;
        coffeaFatigue = Mathf.Clamp01(coffeaFatigue);


        CheckMilestone();
    }

    void CheckMilestone()
    {
        if (plantPopulation >= plantMilestone)
        {
            Debug.Log("Milestone Reached: 1,000,000 Plants!");
            plantGrowth *= 2;
            plantMilestone *= 10;
        }
    }
    
    void EndGame()
    {
        Debug.Log("Game Over");
        enabled = false;
    }
}
