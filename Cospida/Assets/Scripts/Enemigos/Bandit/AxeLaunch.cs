using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeLaunch : MonoBehaviour
{
    GameObject player;
    public Rigidbody2D rb2d;
    Vector3 lastVelocity;
    public float speed;
    public float fuerza;
    public float fuerzaEmpuje;
    public float pushLimit;
    void Start()
    {
        player = GameObject.Find("Player");
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, LayerMask.GetMask("Player"));

        if (hit2D)
        {
            Debug.LogWarning(hit2D.transform.name);
            Debug.LogWarning(hit2D.point);
        }

        rb2d.velocity = ((player.transform.position - transform.position) * Mathf.Max(speed/3, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb2d.velocity = direction * Mathf.Max(speed, 0f);
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy") && EnemigoBasico.canDamage)
        {
            EnemigoBasico.canDamage = false;
            print("pegale we");
            player.GetComponent<PlayerController>().Herirse(fuerza, fuerzaEmpuje, rb2d.velocity, pushLimit);
        }
    }

}
