using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWieght : MonoBehaviour
{
    [SerializeField] List<ObjectInfo> boxes = new List<ObjectInfo>();

    public int totalCount = 0;
    private void Start()
    {
        foreach (Transform obj in transform)
        {
            ObjectInfo objInfo = obj.GetComponent<ObjectInfo>();
            boxes.Add(objInfo);
            totalCount += objInfo.weight;
        }
    }
}
