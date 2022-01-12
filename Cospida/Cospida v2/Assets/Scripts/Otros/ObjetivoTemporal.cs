using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoTemporal : MonoBehaviour
{
    public float time = 4f;
    void Start()
    {
        Invoke("Destruir", time);
    }



    void Destruir()
    {
        Destroy(gameObject);
    }
}
