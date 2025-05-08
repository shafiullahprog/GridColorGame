using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    
    [SerializeField] List<Color> colors = new List<Color>();
    public List<Color> AvailableColors() => colors;

    public Color selectedColor = Color.white;
    [HideInInspector]public Color previousColor;
    private void Awake()
    {
        Instance = this;
    }

    public void SetSelectedColor(int colorIndex)
    {
        if (colorIndex >= 0 && colorIndex < colors.Count)
        {
            selectedColor = colors[colorIndex];
        }
    }

    public void SetSelectedColor(Color color)
    {
        selectedColor = color;
    }

    public void SetSelectedAsWhite()
    {
        previousColor = selectedColor;        
        selectedColor = Color.white;
    }
}
