using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeLaunch : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, LayerMask.GetMask("Player"));

        if (hit2D)
        {
            Debug.LogWarning(hit2D.transform.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
