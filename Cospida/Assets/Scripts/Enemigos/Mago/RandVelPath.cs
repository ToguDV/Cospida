using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class RandVelPath : MonoBehaviour
{
    public AIPath aipath;
    public float maxVel, minVel;
    void Start()
    {
        randomize();
    }



    void randomize()
    {
        float random;
        random = Random.Range(minVel, maxVel);
        aipath.maxSpeed = random;
    }

}
