using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirJuego : MonoBehaviour
{
    // Start is called before the first frame update
    public void Salir()
    {
        SceneManager.LoadScene("Main");
    }
}
