using UnityEngine;
using UnityEngine.UI;

public class CheckEquation : MonoBehaviour
{
    [SerializeField] CheckWieght checkWieght;

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
            }
            else
            {
                Debug.Log("Try Again");
            }
        }
        else
        {
            Debug.Log("Show Answer");
        }
    }
}
