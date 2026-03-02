using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [Header("Node Settings")]
    public string nodeName;
    public int cost = 3;
    public bool unlocked = false;

    [Header("Children")]
    public SkillTree[] children;

    [Header("UI")]
    public GameObject nodeUI;   // The visual button object

    void Start()
    {
        // Hide children at start
        foreach (var child in children)
        {
            child.nodeUI.SetActive(false);
        }
    }

    public void TryUnlock()
    {
        if(GameManager.instance.point < 3) return;
        if (unlocked) return;

        //GameManager.instance.point -= cost;
        unlocked = true;

        // Show children
        foreach (var child in children)
        {
            child.nodeUI.SetActive(true);
            Debug.Log("level up");
        }
        this.GetComponent<Button>().interactable = false;
    }

    void ApplyEffect()
    {
        // Example effects — customize per node
        GameManager.instance.level++;

        if (nodeName == "Crop")
            GameManager.instance.spreadRate += 0.001f;

        if (nodeName == "Domestication")
            GameManager.instance.spreadRate += 0.003f;

        if (nodeName == "Carbohydrate")
            GameManager.instance.spreadRate += 0.005f;
    }
}
