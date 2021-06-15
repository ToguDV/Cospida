using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiodeEscena : MonoBehaviour
{


    public void CambiodeScena(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    void VolverAlMenu()
    {
        CambiodeScena("Main");
    }

}
