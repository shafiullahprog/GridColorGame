using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public int weight;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        weight = 0;
    }
}
