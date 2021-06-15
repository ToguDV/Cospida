using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnZones;
    public GameObject[] fase1;
    public GameObject[] fase2;
    public GameObject[] fase3;
    public GameObject[] fase4;
    public GameObject[] fase5;
    public GameObject[] fase6;
    public GameObject[] fase7;
    public GameObject[] fase8;
    public GameObject[] fase9;
    public GameObject[] fase10;
    public GameObject[] fase11;
    public GameObject[] fase12;
    public GameObject[] fase13;
    public GameObject[] fase14;
    public GameObject[] fase15;
    public GameObject[] fase16;
    public GameObject[] fase17;
    public GameObject[] fase18;
    public GameObject[] fase19;
    public GameObject[] fase20;
    public GameObject[] fase21;
    public GameObject[] fase22;
    public GameObject[] fase23;
    public GameObject[] fase24;
    public GameObject[] fase25;
    public GameObject[] fase26;
    public GameObject[] fase27;
    public GameObject[] fase28;
    public GameObject[] fase29;
    public GameObject[] fase30;
    public float frecuencia;
    public float restTime;
    public bool canSpawn = true;
    int index = 0;
    int spawnIndex = 0;
    public static int faseIndex = 0;
    public int nFases = 5;
    public static int nKillsFase;
    public static int nEnemys;
    public static int nKillsTotal;
    public GameObject[] enemigos;
    public bool canRandom = true;
    public int MaxEnemyOnGame = 4;
    ArenaManager arenaManager;
    FaseController faseController;

    private void Awake()
    {
        arenaManager = GameObject.Find("SceneManager").GetComponent<ArenaManager>();
        faseController = GameObject.Find("UI Fases").GetComponent<FaseController>();
        faseIndex = PlayerPrefs.GetInt("faselvl" + arenaManager.currentLevel + "-" + arenaManager.subLevel, 1);
    }

    void Start()
    {
        spawnIndex = Random.Range(0, spawnZones.Length);
        nKillsTotal = 0;
        index = 0;

        nKillsFase = 0;
        nEnemys = 0;

        if (canSpawn)
        {
            IniciarSpawner();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IniciarSpawner()
    {
        StopCoroutine(Spawnear());
        index = 0;
        StartCoroutine(Spawnear());
    }

    void spawnear()
    {
        //Se instancia los enemigos según los especificados en la lista.
        Instantiate(getFase()[index], spawnZones[spawnIndex].transform.position, spawnZones[spawnIndex].transform.rotation);
        nEnemys++;
        spawnIndex = Random.Range(0, spawnZones.Length);

        index++;
    }

    void spawnRandom()
    {
        //Se instancian enemigos aleatorios.
        Instantiate(enemigos[Random.Range(0, 4)], spawnZones[spawnIndex].transform.position, spawnZones[spawnIndex].transform.rotation);
        nEnemys++;
        spawnIndex = Random.Range(0, spawnZones.Length);

        index++;
    }

    public IEnumerator Spawnear()
    {
        while (faseIndex <= nFases)
        {
            while (index < getFase().Length)
            {

                spawnear();
                yield return new WaitUntil(() => nEnemys - nKillsFase < MaxEnemyOnGame);


                yield return new WaitForSeconds(frecuencia);

            }

            yield return new WaitUntil(() => nKillsFase >= nEnemys);
            nKillsFase = 0;
            nEnemys = 0;
            faseIndex++;
            PlayerPrefs.SetInt("faselvl" + arenaManager.currentLevel + "-" + arenaManager.subLevel, faseIndex);

            faseController.Actualizar();
            index = 0;
            yield return new WaitForSeconds(restTime);
        }



        //Bucle infinito de enemigos qleros jaja salu2
        while (canRandom)
        {
            while (index < 1 + index)
            {
                if (canRandom)
                {

                    spawnRandom();
                }
                yield return new WaitUntil(() => nEnemys - nKillsFase < 4);


                yield return new WaitForSeconds(frecuencia);

            }

            yield return new WaitUntil(() => nKillsFase >= nEnemys);
            nKillsFase = 0;
            nEnemys = 0;
            faseIndex++;
            index = 0;
            yield return new WaitForSeconds(restTime);
        }

        PlayerPrefs.SetString("NivelWin"+arenaManager.currentLevel, "-"+arenaManager.subLevel);
        arenaManager.GanarArena();




    }

    public GameObject[] getFase()
    {
        switch (faseIndex)
        {
            case 1:
                return fase1;
            case 2:
                return fase2;
            case 3:
                return fase3;
            case 4:
                return fase4;
            case 5:
                return fase5;
            case 6:
                return fase6;
            case 7:
                return fase7;
            case 8:
                return fase8;
            case 9:
                return fase9;
            case 10:
                return fase10;
            case 11:
                return fase11;
            case 12:
                return fase12;
            case 13:
                return fase13;
            case 14:
                return fase14;
            case 15:
                return fase15;
            case 16:
                return fase16;
            case 17:
                return fase17;
            case 18:
                return fase18;
            case 19:
                return fase19;
            case 20:
                return fase20;
            case 21:
                return fase21;
            case 22:
                return fase22;
            case 23:
                return fase23;
            case 24:
                return fase24;
            case 25:
                return fase25;
            case 26:
                return fase26;
            case 27:
                return fase27;
            case 28:
                return fase20;
            case 29:
                return fase29;
            case 30:
                return fase30;
            default: return fase1;
        }
    }


}
