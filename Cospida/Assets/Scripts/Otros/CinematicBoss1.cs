using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Diagnostics.Contracts;
using Pathfinding;
using TMPro;

public class CinematicBoss1 : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public GameObject boss;
    public float firstDelay;
    public float lastDelay;
    float timeLastDelay;
    public GameObject player;
    public float speed = 2;
    public Transform camPos;
    public AIPath aIPath;
    public TextMeshProUGUI mensaje;
    public TextMeshProUGUI titulo;
    public string[] mensajes;
    public string[] titulos;
    public bool transicion1IsMaked;
    public bool transicion2IsMaked;
    CinemachineFramingTransposer composer;

    void Start()
    {
        composer = cinemachine.GetCinemachineComponent<CinemachineFramingTransposer>();
        composer.m_DeadZoneWidth = 0f;
        composer.m_DeadZoneHeight = 0f;
        composer.m_SoftZoneHeight = 0f;
        composer.m_SoftZoneWidth = 0f;
        aIPath.canSearch = false;
        PlayerController.canMove = false;
        transicion1IsMaked = false;
        transicion2IsMaked = false;
        timeLastDelay = 0;
        Invoke(nameof(showBoss), firstDelay);
        mensaje.enabled = false;
        titulo.enabled = false;
        int randomM = Random.Range(0, mensajes.Length);
        int randomT = Random.Range(0, titulos.Length);
        titulo.text = titulos[randomT];
        mensaje.text = mensajes[randomM];

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(boss.transform.position, camPos.transform.position) >= 1f && !transicion1IsMaked)
        {
            camPos.position += (new Vector3(boss.transform.position.x, boss.transform.position.y, camPos.position.z) -
            camPos.transform.position).normalized * speed * Time.deltaTime;
        }

        else
        {
            transicion1IsMaked = true;
            timeLastDelay += Time.deltaTime;
            if (timeLastDelay >= lastDelay)
            {
                mensaje.enabled = false;
                titulo.enabled = false;
                if (Vector2.Distance(player.transform.position, camPos.transform.position) > 5f && !transicion2IsMaked)
                {
                    camPos.position += (new Vector3(player.transform.position.x, player.transform.position.y, camPos.position.z) -
                    camPos.transform.position).normalized * speed*1.5f * Time.deltaTime;
                }

                else
                {
                    
                    aIPath.canSearch = true;
                    PlayerController.canMove = true;
                    transicion2IsMaked = true;
                    cinemachine.Follow = player.transform;
                    composer.m_DeadZoneWidth = 0.25f;
                    composer.m_DeadZoneHeight = 0.25f;
                    composer.m_SoftZoneHeight = 0.3f;
                    composer.m_SoftZoneWidth = 0.3f;
                    Destroy(gameObject);

                }
            }

            else
            {
                mensaje.enabled = true;
                titulo.enabled = true;
            }
            
        }
    }


    public void showBoss()
    {
        cinemachine.Follow = null;
    }
}
