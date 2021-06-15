using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTransform : MonoBehaviour
{
    public Transform toFollow;
    public Transform follower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        follower = toFollow;
    }
}
