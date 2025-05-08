using UnityEngine;
using UnityEngine.EventSystems;

public class GridSquare : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Color currentColor = Color.white;
    [SerializeField] private bool isColored = false;

    private void Awake()
    {
        spriteRenderer.color = Color.white;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        ToggleColor();
    }

    private void ToggleColor()
    {
        if (isColored)
        {
            var color = ColorManager.Instance;
            color.SetSelectedAsWhite();
            spriteRenderer.color = color.selectedColor;
            currentColor = spriteRenderer.color;
            isColored = false;
            
            UIManager.Instance.UpdateAllIndicators();
            color.SetSelectedColor(color.previousColor);
        }
        else
        {
            spriteRenderer.color = ColorManager.Instance.selectedColor;
            currentColor = spriteRenderer.color;
            isColored = true;
            UIManager.Instance.UpdateAllIndicators();
        }
    }
}
