using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquationDivisorValue : MonoBehaviour
{
    [SerializeField] CheckWeight checkWeight;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TMP_InputField divisableNum;
    [SerializeField] Button submitButton;

    private void Start()
    {
        //ResultAfterSub();
        submitButton.onClick.AddListener(CheckUserInput);
    }

    public void ResultAfterSub()
    {
        int lhs = checkWeight.equation.X;
        int rhs = checkWeight.equation.Total - checkWeight.equation.Num;

        resultText.text += $" {checkWeight.equation.X}x = {rhs}\n";
    }

    public void CheckUserInput()
    {
        if (int.Parse(divisableNum.text) == checkWeight.equation.X)
        {
            Debug.Log("Well Done");
        }
        else
        {
            Debug.Log("Try Again");
        }
    }
}
