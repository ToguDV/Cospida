using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BanditKnifeController : EnemigoBasico
{
    Vector3 last = Vector3.zero;
    public GameObject[] attackPositions;
    public GameObject padre;
    public AIPath aipath;
    public AIDestinationSetter destination;
    // Start is called before the first frame update
    void Awake()
    {
        movimiento = true;
        Inicial(); //Se inicializan los componentes heredados. (Este es un método heredado)
    }
    public void DeletePadre()
    {
        Destroy(padre);
    }
    public void Movimiento()
    {

        if (movimiento && !animator.GetBool("isDamaged"))
        {

            movement = aipath.velocity;
            // movement = ((objetivo - transform.position).normalized)*velocidad;
            if (!animator.GetBool("isDamaged"))
            {
                animator.SetFloat("x", movement.x);
                animator.SetFloat("y", movement.y);
            }
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

    public void setMovement(Vector2 movement)
    {
        this.movement = movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul"))
        {
            
            animator.SetBool("isAtacking", true);
        }
        
    }

    
}
