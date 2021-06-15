using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    Sonido sound;

    void Start()
    {
       sound = GameObject.Find("ControladorSonido").GetComponent<Sonido>();
        sound.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
