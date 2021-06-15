using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilSlimeKing : MonoBehaviour
{
    GameObject objetivo;
    Vector2 playerPos;
    RaycastHit2D hit;
    public float speed = 5;
    public float fuerza;
    public float fuerzaEmpuje;
    public Vector3 pushVelocity;
    public float pushLimit;
    void Start()
    {
        objetivo = GameObject.Find("Player");
        playerPos = new Vector2(objetivo.transform.position.x - transform.position.x, objetivo.transform.position.y - transform.position.y);
        hit = Physics2D.Raycast(transform.position, playerPos, Mathf.Infinity, LayerMask.GetMask("Obstacle"));

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(hit.point, transform.position) >= 0.1f)
        {

            transform.position += (new Vector3(hit.point.x, hit.point.y) - transform.position).normalized * speed * Time.deltaTime;
            pushVelocity = (new Vector3(hit.point.x, hit.point.y) - transform.position).normalized * speed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstaculo"))
        {

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (EnemigoBasico.canDamage)
            {
                EnemigoBasico.canDamage = false;
                collision.gameObject.GetComponent<PlayerController>().Herirse(fuerza, fuerzaEmpuje, pushVelocity, pushLimit);
            }
            Destroy(gameObject);
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (EnemigoBasico.canDamage)
            {
                EnemigoBasico.canDamage = false;
                collision.gameObject.GetComponent<PlayerController>().Herirse(fuerza, fuerzaEmpuje, pushVelocity, pushLimit);
            }
            Destroy(gameObject);
        }
    }
}
