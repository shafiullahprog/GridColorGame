using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteChange : MonoBehaviour
{
    public Toggle toggle;
    public Image image;
    public Color SelectedColor, UnselectedColor;
    public int index;


    [SerializeField] bool IsDependency = false;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnToggleClicked()
    {
        if (image!=null)
            image.color = toggle.isOn ? SelectedColor : UnselectedColor;
    
        if(toggle.isOn && IsDependency)
        {
            ColorManager.Instance.SetSelectedColor(index);
        }
    }
}
