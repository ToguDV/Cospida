using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoIdentificador : MonoBehaviour
{
    GameObject player;
    public float speed = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
