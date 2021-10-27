using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjectOnCollide : MonoBehaviour
{
    public GameObject objToEnable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objToEnable.SetActive(true);
        }
    }
}
