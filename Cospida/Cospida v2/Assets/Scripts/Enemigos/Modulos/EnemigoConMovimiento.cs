using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemigoConMovimiento : EnemigoBasico
{
    Vector3 last = Vector3.zero;
    public GameObject sudor;
    public GameObject padre;
    public AIPath aipath;
    public AIDestinationSetter destination;
    public bool combed = false;
    public int nCombed;
    public CircleCollider2D collider2D;
    int combo;
    public GameObject[] attack1Positions;
    public GameObject[] attack2Positions;
    public static int currentFase;
    public Ballesta[] ballestas;
    public GameObject dialogo;
    public GameObject cinematicaFinal;
    public GameObject positionDeath;
    public GameObject positionDeathPlayer;
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
            movement = aipath.desiredVelocity;
            pushVelocity = aipath.velocity;
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

    public void SetAnimatorBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }

    private void Update()
    {
        if(vida >= 30)
        {
            currentFase = 1;
        }

        else if (vida >= 25)
        {
            currentFase = 2;
        }

        else if (vida >= 15)
        {
            currentFase = 3;
        }

        else if (vida <= 0)
        {
            animator.SetBool("isDeath", true);
            cinematicaFinal.SetActive(true);
            padre.transform.position = positionDeath.transform.position;
            objetivo.transform.position = positionDeathPlayer.transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ataque") && isProtected && !CorriendoBanditBoss.isRunAttack2)
        {
            animator.SetBool("isMiss", true);
            combo++;
            if (combo >= nCombed)
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

    public void Sweat()
    {
        GameObject temp;
        temp = Instantiate(sudor, new Vector3(0.05f, 1.2f), transform.rotation);
        temp.transform.SetParent(gameObject.transform, false);
    }
}
