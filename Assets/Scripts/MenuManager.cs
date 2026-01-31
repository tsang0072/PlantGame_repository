using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField sugarInput;
    public TMP_InputField beanInput;
    public TMP_InputField coffeaInput;

    public Button continueButton;
    public GameObject inputPanel;

    oldGameManager gm;

    void Start()
    {
        gm=oldGameManager.instance;
        inputPanel.SetActive(false);
    }

    void Update()
    {
        
    }
    public void OnStopPressed()
    {
        gm.StopGame();
        inputPanel.SetActive(true);
        SyncFromGameManager();
    }

    public void OnContinuePressed()
    {
        if (!IsInputValid())
            return;

        ApplyToGameManager();
        inputPanel.SetActive(false);
        gm.ContinueGame();
    }
    public void OnValueChanged()
    {
        continueButton.interactable = IsInputValid();
    }

    // =========================
    // CORE LOGIC
    // =========================

    bool IsInputValid()
    {
        int sugar = GetInputValue(sugarInput);
        int bean = GetInputValue(beanInput);
        int coffea = GetInputValue(coffeaInput);

        int total = sugar + bean + coffea;

        return total == 100 &&
               sugar >= 0 && bean >= 0 && coffea >= 0;
    }

    void ApplyToGameManager()
    {
        gm.sugarPercent = GetInputValue(sugarInput);
        gm.beanPercent = GetInputValue(beanInput);
        gm.coffeaPercent = GetInputValue(coffeaInput);
    }
    void SyncFromGameManager()
    {
        sugarInput.text = gm.sugarPercent.ToString();
        beanInput.text = gm.beanPercent.ToString();
        coffeaInput.text = gm.coffeaPercent.ToString();

        continueButton.interactable = true;
    }


    int GetInputValue(TMP_InputField input)
    {
        if (int.TryParse(input.text, out int value))
            return Mathf.Clamp(value, 0, 100);

        return 0;
    }
}
