using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaDesdeInicio : MonoBehaviour
{
    ArenaManager arenaManager;
    private void Start()
    {
        try
        {
          arenaManager = GameObject.Find("SceneManager").GetComponent<ArenaManager>();
        }
        catch (System.Exception)
        {

           
        }
    }
    public void ejecutar()
    {
        if (arenaManager) {
        PlayerPrefs.SetInt("faselvl" + arenaManager.currentLevel + "-" + arenaManager.subLevel, 1);
        }

        else
        {
            Debug.Log("No se encontro el SceneManager");
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
