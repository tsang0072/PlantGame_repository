using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [Header("Infection Visual")]
    public Color infectionColor = Color.red;
    public float smoothSpeed = 2f;

    private Renderer rend;
    private Material materialInstance;
    private Color originalColor;
    private Color targetColor;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // IMPORTANT: unique material instance
        materialInstance = rend.material;

        originalColor = materialInstance.color;
        targetColor = originalColor;
    }

    void Update()
    {
        if (!GameManager.instance.gameRunning)
            return;

        float infectionPercent = GameManager.instance.addictPercentage / 100f;

        targetColor = Color.Lerp(originalColor, infectionColor, infectionPercent);

        materialInstance.color = Color.Lerp(
            materialInstance.color,
            targetColor,
            Time.deltaTime * smoothSpeed
        );
    }
}
