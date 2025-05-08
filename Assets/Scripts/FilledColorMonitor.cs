using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FilledColorMonitor : MonoBehaviour
{
    [Header("Indicator Settings")]
    private Image indicatorImage;
    private Color targetColor;
    [SerializeField] private TextMeshProUGUI percentageText;

    [SerializeField] private int totalGrids;

    private void Start()
    {
        indicatorImage = GetComponent<Image>();
        targetColor = indicatorImage.color;

        UIManager.Instance.OnGridSpawned.AddListener(Initialize);
    }

    public void Initialize()
    {
        totalGrids = UIManager.Instance.AllGridSquares.Count;
        UpdatePercentage();
    }

    // Updates the percentage display
    public void UpdatePercentage()
    {
        var grids = UIManager.Instance.AllGridSquares;
        if (totalGrids == 0) return;

        int colorCount = 0;
        foreach (var square in grids)
        {
            if (square.currentColor == targetColor)
            {
                colorCount++;
            }
        }

        float percentage = (float)colorCount / totalGrids * 100f;
        percentageText.text = $"{percentage:F1}%";
    }

}
