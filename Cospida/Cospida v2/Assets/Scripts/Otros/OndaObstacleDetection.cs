using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaObstacleDetection : MonoBehaviour
{

    public GameObject padre;
    public GameObject deleteEffect;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            if (collision.gameObject != null)
            {
                Instantiate(deleteEffect, new Vector3(transform.position.x, transform.position.y, -4.3f), Quaternion.identity);
                Destroy(padre);
            }

        }

    }
}
