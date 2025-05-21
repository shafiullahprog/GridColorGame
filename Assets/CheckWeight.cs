using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeight : MonoBehaviour
{
    public Equation equation;

    public GameObject boxPrefab;
    public GameObject applePrefab;

    public Transform leftPlate;
    public Transform rightPlate;

    [SerializeField] private List<ObjectInfo> leftObjects = new List<ObjectInfo>();
    [SerializeField] private List<ObjectInfo> rightObjects = new List<ObjectInfo>();



    public int TotalAppleToRemove = 0, TotalRHSValue;
    /*public void InstantiateObjectsFromEquation()
    {
        int boxCount = equation.X;
        int lhsAppleCount = equation.Num;
        int rhsAppleCount = equation.Total;

        int xValue = equation.GetXValue();
        int appleWeight = 1;

        // LHS Boxes + Apples
        for (int i = 0; i < boxCount; i++)
        {
            GameObject box = Instantiate(boxPrefab, leftPlate.position + new Vector3(i * 0.3f, 0, 0), Quaternion.identity, leftPlate);
            var info = box.GetComponent<ObjectInfo>();
            info.weight = xValue;
            info.objectType = ObjectType.Box;
            leftObjects.Add(info);
        }

        for (int i = 0; i < lhsAppleCount; i++)
        {
            GameObject apple = Instantiate(applePrefab, leftPlate.position + new Vector3(i * 0.5f, 1f, 0), Quaternion.identity, leftPlate);
            var info = apple.GetComponent<ObjectInfo>();
            info.weight = appleWeight;
            info.objectType = ObjectType.Apple;
            leftObjects.Add(info);
        }

        // RHS → Only Apples
        for (int i = 0; i < rhsAppleCount; i++)
        {
            GameObject apple = Instantiate(applePrefab, rightPlate.position + new Vector3(i * 0.5f, 0, 0), Quaternion.identity, rightPlate);
            var info = apple.GetComponent<ObjectInfo>();
            info.weight = appleWeight;
            info.objectType = ObjectType.Apple;
            rightObjects.Add(info);
        }

        Debug.Log("Left Total: " + GetTotalWeight(leftObjects) + " | Right Total: " + GetTotalWeight(rightObjects));
    }*/

    public void InstantiateObjectsFromEquation()
    {
        int boxCount = equation.X;
        int lhsAppleCount = equation.Num;
        int rhsAppleCount = equation.Total;

        TotalAppleToRemove = lhsAppleCount;

        int xValue = equation.GetXValue(); // box weight
        int appleWeight = 1;

        // LHS → Boxes
        SpawnStackedObjects(boxPrefab, leftPlate, boxCount, xValue, ObjectType.Box, leftObjects);

        // LHS → Apples
        SpawnStackedObjects(applePrefab, leftPlate, lhsAppleCount, appleWeight, ObjectType.Apple, leftObjects, startY: 1f);

        // RHS → Apples only
        SpawnStackedObjects(applePrefab, rightPlate, rhsAppleCount, appleWeight, ObjectType.Apple, rightObjects);

        foreach (ObjectInfo obj in rightObjects)
        {
            obj.enabled = false;
        }
        Debug.Log("Left Total: " + GetTotalWeight(leftObjects) + " | Right Total: " + GetTotalWeight(rightObjects));
    }

    void SpawnStackedObjects(GameObject prefab, Transform parent, int count, int weight, ObjectType type, List<ObjectInfo> list, float startY = 0f)
    {
        int rowLimit = 4;               // Max per row
        float spacing = 0.2f;           // Horizontal spacing
        float verticalSpacing = 0.3f;   // Vertical spacing

        for (int i = 0; i < count; i++)
        {
            int row = i / rowLimit;
            int col = i % rowLimit;

            Vector3 position = parent.position +
                               new Vector3(col * spacing, startY + row * verticalSpacing, 0);

            GameObject obj = Instantiate(prefab, position, Quaternion.identity, parent);
            ObjectInfo info = obj.GetComponent<ObjectInfo>();
            info.weight = weight;
            info.objectType = type;
            list.Add(info);
        }
    }
    int GetTotalWeight(List<ObjectInfo> objs)
    {
        int sum = 0;
        foreach (var obj in objs)
        {
            sum += obj.weight;
        }
        return sum;
    }
}
