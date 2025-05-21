using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetEquation : MonoBehaviour
{
    public Equation equation;
    public CheckWeight controller;
    public GameObject canvasObj;

    TextMeshProUGUI textMeshPro;
    [SerializeField] TextMeshProUGUI setText;
    Button button;

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        textMeshPro.text = equation.ToString();
        
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                SetEquationValue();
            });
        }
    }

    void SetEquationValue()
    {
        controller.equation = equation;
        controller.InstantiateObjectsFromEquation();
        canvasObj.SetActive(false);
    }

    public void SetOnText()
    {
        setText.text = equation.ToString();
    }    
}
