using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    [Header("Tipo de escena a cambiar")]
    [Tooltip("0 = SiguienteNivel, 1=AbrirMenu")]
    public int typeToChange;

    public int currentLevel;
    public int subLevel;
    public GameObject menuWin;
    public GameObject btnExplorar;
    public GameObject btnSiguienteArena;
    public bool nextIsBoss = true;
    GameObject calavera;
    Animator animCalavera;
    public float bossDelay = 5f;

    private void Start()
    {
        calavera = GameObject.Find("calavera");
        animCalavera = calavera.GetComponent<Animator>();
        menuWin.SetActive(false);
    }

    public void GanarArena()
    {


        if (nextIsBoss)
        {
            animCalavera.SetBool("active", true);
            Invoke("BossDelay", bossDelay);
        }

        else
        {


            if (typeToChange == 0)
            {
                menuWin.SetActive(true);
                btnSiguienteArena.SetActive(true);
                btnExplorar.SetActive(false);
            }

            if (typeToChange == 1)
            {
                btnSiguienteArena.SetActive(false);
                btnExplorar.SetActive(true);
                menuWin.SetActive(true);

            }

        }


    }

    public void BossDelay()
    {
        PasarArena.ToBoss(currentLevel, subLevel);
    }
}
