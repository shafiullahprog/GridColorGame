using UnityEngine;

public enum ObjectType
{
    Box,
    Apple
}

public class ObjectInfo : MonoBehaviour
{

    public int weight;
    public ObjectType objectType;

    CheckWeight checkWieght;

    private void Start()
    {
        checkWieght = FindObjectOfType<CheckWeight>();
    }

    private void OnMouseDown()
    {
        if (objectType == ObjectType.Apple && this.isActiveAndEnabled)
        {
            Debug.Log($"{gameObject.name} removed");
            weight = 0;
            this.gameObject.SetActive(false);
            checkWieght.TotalAppleToRemove -= 1;
        }
    }
}
