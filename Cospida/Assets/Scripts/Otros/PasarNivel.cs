using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasarNivel : MonoBehaviour
{
    CambiodeEscena cambioescena;

    void Awake()
    {
        cambioescena = GameObject.Find("CambiodeEscena").GetComponent(typeof(CambiodeEscena)) as CambiodeEscena;
    }
    // Start is called before the first frame update
    
   
}
