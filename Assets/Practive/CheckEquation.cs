using UnityEngine;
using UnityEngine.UI;

public class CheckEquation : MonoBehaviour
{
    [SerializeField] GameObject divisionPanel;
    [SerializeField] GameObject equationCheckPanel;
    [SerializeField] CheckWeight checkWieght;
    [SerializeField] EquationDivisorValue equationDivisorValue;

    [SerializeField] Button checkButton;
    [SerializeField] int checkCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        checkButton.onClick.AddListener(CheckEquationValue);
    }

    public void CheckEquationValue()
    {
        if (checkCount < 2)
        {
            checkCount++;
            if(checkWieght.TotalAppleToRemove == 0)
            {
                Debug.Log("Correct");
                EnableNextPage();
            }
            else
            {
                Debug.Log("Try Again");
                if (checkCount == 2)
                {
                    EnableNextPage();
                    Debug.Log("Show Answer");
                }
            }
        }
        else
        {
            divisionPanel.SetActive(true);
            EnableNextPage();
            Debug.Log("Show Answer 1");
        }
    }

    private void EnableNextPage()
    {
        equationCheckPanel.SetActive(false);
        divisionPanel.SetActive(true);
        equationDivisorValue.ResultAfterSub();
    }
}
