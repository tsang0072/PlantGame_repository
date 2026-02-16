using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsManager : MonoBehaviour
{
    public static NewsManager instance;

    public GameObject News50K;
    public GameObject News100K;
    public GameObject News500K;

    private bool news50KShown = false;
    private bool news100KShown = false;
    private bool news500KShown = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        News50K.SetActive(false);
        News100K.SetActive(false);
        News500K.SetActive(false);
    }

    public void CheckMilestones(int addictCount)
    {
        if (addictCount >= 50000 && !news50KShown)
        {
            StartCoroutine(ShowNewsForSeconds(News50K));
            news50KShown = true;
        }

        if (addictCount >= 100000 && !news100KShown)
        {
            StartCoroutine(ShowNewsForSeconds(News100K));
            news100KShown = true;
        }

        if (addictCount >= 5000000 && !news500KShown)
        {
            StartCoroutine(ShowNewsForSeconds(News500K));
            news500KShown = true;
        }
    }

    IEnumerator ShowNewsForSeconds(GameObject newsObject)
    {
        newsObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        newsObject.SetActive(false);
    }
}
