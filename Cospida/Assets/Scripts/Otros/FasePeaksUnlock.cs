using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasePeaksUnlock : MonoBehaviour
{
    public GameObject[] peaksSect;
    int actuFase;
    public GameObject[] spawnPointZone1, spawnPointZone2, spawnPointZone3, spawnPointZone4;
    public Spawner spawner;
    ArenaManager arenaManager;
    public GameObject[] spawnsPlayer;
    public GameObject player;
    void Awake()
    {
        arenaManager = GameObject.Find("SceneManager").GetComponent<ArenaManager>();
        Spawner.faseIndex = PlayerPrefs.GetInt("faselvl" + arenaManager.currentLevel + "-" + arenaManager.subLevel, 1);
        actuFase = 0;
        Debug.Log(Spawner.faseIndex);
        player.transform.position = spawnsPlayer[Spawner.faseIndex - 1].transform.position;
        if (Spawner.faseIndex > spawner.nFases && spawner.getActive())
        {
            spawner.StopSpawner();
        }
        switch (Spawner.faseIndex)
        {
            case 1:
                spawner.spawnZones = spawnPointZone1;
                break;
            case 2:
                spawner.spawnZones = spawnPointZone2;
                break;
            case 3:
                spawner.spawnZones = spawnPointZone3;
                break;
            case 4:
                spawner.spawnZones = spawnPointZone4;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (Spawner.faseIndex > spawner.nFases && spawner.getActive())
        {
            spawner.StopSpawner();
        }

        if (Spawner.faseIndex > actuFase + 1)
        {
            
            
            switch (Spawner.faseIndex)
            {
                case 1:
                    spawner.spawnZones = spawnPointZone1;
                    break;
                case 2:
                    spawner.spawnZones = spawnPointZone2;
                    break;
                case 3:
                    spawner.spawnZones = spawnPointZone3;
                    break;
                case 4:
                    
                    spawner.spawnZones = spawnPointZone4;
                    break;
                default:
                    break;
            }

            PeaksController[] tempPeaks;
            tempPeaks = peaksSect[actuFase].GetComponentsInChildren<PeaksController>();
            foreach (PeaksController peak in tempPeaks)
            {
                peak.TriggerSetter(true);
                peak.ManualDesactivation();
            }
            actuFase++;
        }
    }
}
