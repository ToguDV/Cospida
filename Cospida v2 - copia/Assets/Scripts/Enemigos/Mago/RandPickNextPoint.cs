using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class RandPickNextPoint : MonoBehaviour
{
    public AIPath aipath;
    public float maxRadius, minRadius;
    void Start()
    {
        aipath.pickNextWaypointDist = Random.Range(minRadius, maxRadius);
    }

}
