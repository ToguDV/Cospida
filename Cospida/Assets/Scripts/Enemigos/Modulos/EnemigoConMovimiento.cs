using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemigoConMovimiento : EnemigoBasico
{
    Vector3 last = Vector3.zero;
    public GameObject padre;
    public AIPath aipath;
    public AIDestinationSetter destination;
    public bool combed = false;
    public CircleCollider2D collider2D;
    int combo;
    public GameObject[] attack1Positions;
    // Start is called before the first frame update
    void Awake()
    {
        isProtected = true;
        combo = 0;
        combed = false;
        movimiento = true;
        Inicial(); //Se inicializan los componentes heredados. (Este es un método heredado)
    }
    public void Movimiento()
    {

        if (movimiento && !animator.GetBool("isDamaged"))
        {

            movement = aipath.velocity;
            movement.Normalize();
            movement.x = Mathf.RoundToInt(movement.x);
            movement.y = Mathf.RoundToInt(movement.y);
            // movement = ((objetivo - transform.position).normalized)*velocidad;
            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
        }
    }

    public bool getMovimiento()
    {
        return movimiento;
    }
    public Vector2 getMovement()
    {
        return movement;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ataque") && isProtected)
        {
            animator.SetBool("isMiss", true);
            combo++;
            if (combo >= 2)
            {
                isProtected = true;
                combo = 0;
                combed = true;
            }
        }

        if (collision.gameObject.CompareTag("ataque") && !gameObject.CompareTag("Untagged"))
        {

            
        }


    }
}
