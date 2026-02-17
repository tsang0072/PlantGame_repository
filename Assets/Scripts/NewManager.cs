using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NewsManager : MonoBehaviour
{
    public enum MilestoneType
{
    Addiction,
    Awareness
}

    [System.Serializable]
public class NewsMilestone
{
    public MilestoneType type;
    public int threshold;
    public GameObject newsObject;

    [HideInInspector]
    public bool hasShown;
}

   public static NewsManager instance;

    public List<NewsMilestone> milestones = new List<NewsMilestone>();

    public float displayTime = 2f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (var milestone in milestones)
        {
            milestone.newsObject.SetActive(false);
            milestone.hasShown = false;
        }
    }

    public void CheckMilestones(int addictCount, int awarenessLevel)
    {
        foreach (var milestone in milestones)
        {
            if (milestone.hasShown)
                continue;

            switch (milestone.type)
            {
                case MilestoneType.Addiction:
                    if (addictCount >= milestone.threshold)
                        TriggerMilestone(milestone);
                    break;

                case MilestoneType.Awareness:
                    if (awarenessLevel >= milestone.threshold)
                        TriggerMilestone(milestone);
                    break;
            }
        }
    }

    void TriggerMilestone(NewsMilestone milestone)
    {
        milestone.hasShown = true;
        Debug.Log("news: " + milestone.type);
        StartCoroutine(ShowNews(milestone));
    }

    IEnumerator ShowNews(NewsMilestone milestone)
    {
        milestone.newsObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        milestone.newsObject.SetActive(false);
    }
}
