using UnityEngine;

public class BalanceScaleManager : MonoBehaviour
{
    public Transform leftPlate;
    public Transform rightPlate;

    public GameObject applePrefab;
    public GameObject boxPrefab;

    public Vector3 leftStartPos = new Vector3(-1, 1, 0);
    public Vector3 rightStartPos = new Vector3(1, 1, 0);

    private int leftItemCount = 0;
    private int rightItemCount = 0;

    void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        // Example: 2 boxes + 1 apple on LHS, 9 apples on RHS
        SpawnBox(leftPlate, 2);
        SpawnApple(leftPlate, 1);
        SpawnApple(rightPlate, 9);
    }

    void SpawnBox(Transform plate, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = plate.position + new Vector3(0, 0.2f * i, 0);
            Instantiate(boxPrefab, pos, Quaternion.identity);
        }
    }

    void SpawnApple(Transform plate, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = plate.position + new Vector3(0.2f * (i % 3), 0.2f * (i / 3), 0);
            Instantiate(applePrefab, pos, Quaternion.identity);
        }
    }
}
