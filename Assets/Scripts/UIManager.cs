using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Grid and Indicators")]
    [SerializeField] private List<FilledColorMonitor> indicators;
    [SerializeField] private List<GridSquare> allGridSquares;

    public List<GridSquare> AllGridSquares => allGridSquares;

    [Header("UI Elements")]
    [SerializeField] private Transform buttonParent; 
    [SerializeField] private Transform indicatorParent;
    [SerializeField] private GameObject colorButtonPrefab;
    [SerializeField] private GameObject percentageIndicatorPrefab;

    [SerializeField] GameObject gridParent;

    public UnityEvent OnGridSpawned;

    private float darkenFactor = 0.3f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetUpToggle();
        //InitializeIndicators();
    }

    public void SetUpToggle()
    {
        List<Color> colors = ColorManager.Instance.AvailableColors();

        if (colors.Count > 0)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                ToggleSpawner(colors[i], i);
                PercentageIndicatorSpawner(colors[i]);
            }
            PercentageIndicatorSpawner(Color.white);
        }
        Invoke(nameof(DataLoaded), 0.3f);
    }

    private void ToggleSpawner(Color color, int i)
    {
        GameObject toggleObj = Instantiate(colorButtonPrefab, buttonParent);
        ToggleSpriteChange toggle = toggleObj.GetComponent<ToggleSpriteChange>();
        toggle.toggle.group = buttonParent.GetComponent<ToggleGroup>();

        toggle.SelectedColor = color;
        toggle.UnselectedColor = DarkenColor(color);

        toggle.index = i;
        toggle.OnToggleClicked();
    }

    private void PercentageIndicatorSpawner(Color color)
    {
        GameObject toggleObj = Instantiate(percentageIndicatorPrefab, indicatorParent);
        Image image = toggleObj.GetComponent<Image>();
        image.color = color;
    }

    private Color DarkenColor(Color color)
    {
        float r = color.r * (1 - darkenFactor);
        float g = color.g * (1 - darkenFactor);
        float b = color.b * (1 - darkenFactor);
        return new Color(r, g, b, color.a);
    }

    public void UpdateAllIndicators()
    {
        foreach (var indicator in indicators)
        {
            indicator.UpdatePercentage();
        }
    }

    private void DataLoaded()
    {
        allGridSquares = new List<GridSquare>(gridParent.GetComponentsInChildren<GridSquare>());
        indicators = new List<FilledColorMonitor>(indicatorParent.GetComponentsInChildren<FilledColorMonitor>());
        OnGridSpawned?.Invoke();
    }
}
