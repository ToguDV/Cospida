using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathClean : MonoBehaviour
{
    public float ratio = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateAllPath" , 0f, ratio);
    }

    // Update is called once per frame
    void updateAllPath()
    {
        AstarPath.active.Scan();
    }
}
