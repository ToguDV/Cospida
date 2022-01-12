using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coreGanar : MonoBehaviour
{



    public static void Ganar(int idNivel, string enviarA)
    {
        Puertas.activarPuerta(idNivel);
        SceneManager.LoadScene(enviarA);
    }
}
