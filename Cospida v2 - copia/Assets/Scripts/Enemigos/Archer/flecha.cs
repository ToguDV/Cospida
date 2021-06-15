using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    GameObject player;
    public float velocidad1;
    public float velocidad2;
    public float duracion = 0.2f;
    float time;
    Vector2 posOld;
    public int direction;
    public float fuerza;
    public float fuerzaEmpuje;
    public Vector3 pushVelocity;
    public float pushLimit;
    void Start()
    {
        time = 0;
        player = GameObject.Find("Player");
        posOld = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        switch (direction)
        {
            case 1:
                if (time < duracion)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(posOld.x, transform.position.y), velocidad1 * Time.deltaTime);
                    pushVelocity = Vector2.up;

                }
                transform.position = new Vector2(transform.position.x, transform.position.y + velocidad2);

                break;

            case 2:
                if (time < duracion)
                {
                    pushVelocity = Vector2.down;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(posOld.x, transform.position.y), velocidad1 * Time.deltaTime);

                }
                transform.position = new Vector2(transform.position.x, transform.position.y - velocidad2);

                break;

            case 3:
                if (time < duracion)
                {
                    pushVelocity = Vector2.right;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, posOld.y), velocidad1 * Time.deltaTime);

                }
                transform.position = new Vector2(transform.position.x + velocidad2, transform.position.y);

                break;

            case 4:
                if (time < duracion)
                {
                    pushVelocity = Vector2.left;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, posOld.y), velocidad1 * Time.deltaTime);

                }
                transform.position = new Vector2(transform.position.x - velocidad2, transform.position.y);

                break;

            default:
                break;
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
