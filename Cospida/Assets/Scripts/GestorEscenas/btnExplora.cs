using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnExplora : MonoBehaviour
{
    ArenaManager arenaManager;
    private void Start()
    {
        arenaManager = GameObject.Find("SceneManager").GetComponent<ArenaManager>();
    }


    public void btnClick()
    {
        PasarArena.ToExplorationMode(arenaManager.currentLevel);
    }
}
