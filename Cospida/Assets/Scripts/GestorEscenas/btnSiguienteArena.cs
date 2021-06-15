using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSiguienteArena : MonoBehaviour
{
    ArenaManager arenaManager;
    private void Start()
    {
        arenaManager = GameObject.Find("SceneManager").GetComponent<ArenaManager>();
    }


    public void btnClick()
    {
        PasarArena.ToNextArena(arenaManager.currentLevel, arenaManager.subLevel);
    }
}
