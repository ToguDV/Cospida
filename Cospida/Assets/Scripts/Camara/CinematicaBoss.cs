using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class CinematicaBoss : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject UICanvasObj;
    CinemachineVirtualCamera cinemachine;
    public GameObject boss;
    void Awake()
    {
        UICanvasObj.SetActive(false);
        cinemachine = GameObject.Find("CM").GetComponent<CinemachineVirtualCamera>();
    }

    public void Activar()
    {
        cinemachine.m_Follow = boss.transform; 
        UICanvasObj.SetActive(true);
    }
}
