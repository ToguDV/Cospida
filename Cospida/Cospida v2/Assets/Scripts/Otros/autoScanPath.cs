using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScanPath : MonoBehaviour
{
    public float ratio;
    void Start()
    {
        InvokeRepeating("scanPath", 0, ratio);
    }

    void scanPath()
    {
        AstarPath.active.UpdateGraphs(gameObject.GetComponent<Collider2D>().bounds);
    }
}
