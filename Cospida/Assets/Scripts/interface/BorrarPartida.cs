using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarPartida : MonoBehaviour
{
    public int nCiclos;
    public void Borrar()
    {
        for (int i = 0; i < nCiclos; i++)
        {
            PlayerPrefs.SetInt("faselvl" + i, 1);
            PlayerPrefs.SetInt("Puerta" + i, 0);
        }
        
    }
}
