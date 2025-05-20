using UnityEngine;

public class WeighingMachineController : MonoBehaviour
{
    [SerializeField] Equation equation;
    [SerializeField] CheckWieght LHS, RHS;

    private void Start()
    {
        Debug.Log(equation.GetXValue());
    }
    public void BalanceWeight()
    {
        
        if(LHS.totalCount > RHS.totalCount)
        {
            Debug.Log("Goes up on RHS");
        }
        else if(RHS.totalCount > LHS.totalCount)
        {
            Debug.Log("Goes up on LHS");
        }
        else
        {
            Debug.Log("Balanced Weight");
        }
    }
}
