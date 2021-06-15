using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeController : EnemigoBasico
{
    public float frecuencia; //Frecuencia de ataque.
    public float duracion; //(Duración de ataque)
    bool movimiento = false;
    Vector3 last = Vector3.zero; //Es la última posición obtenida del jugador antes de saltar a atacarlo.
    public Vector3 test;
    public bool igualx, igualy;
    public bool firstIAttack = true;
    public bool transicion = false;
    public static int direccionTransicion = 1;

    void Start()
    {
        Inicial(); //Se inicializan los componentes heredados. (Este es un método heredado)
        if (transicion)
        {
            direccionTransicion *= -1;
            rigidbody2D.velocity = (new Vector2(velocidad * direccionTransicion, 0));
          
          
        }
        
        frecuencia = Random.Range(frecuencia - 1, frecuencia);

        //Se inicia el ciclo entre atacar y quedarse quieto.
        InvokeRepeating("ActivarMovimiento", frecuencia, frecuencia);
        InvokeRepeating("DesactivarMovimiento", frecuencia + duracion, frecuencia);
       // rigidbody2D.isKinematic = true;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        
    }

    void Update()
    {
       
        Movimiento();

    }

    private void FixedUpdate()
    {
        if (movimiento) { 
        rigidbody2D.velocity = movement * velocidad;
        }
        if (firstIAttack)
        {
            pushVelocity = rigidbody2D.velocity;
            firstIAttack = false;
        }
    }





    public override void Movimiento()
    {
        
        if (movimiento && !animator.GetBool("isDamaged"))
        {




            movement = (last - transform.position).normalized;

            


           
            /* pushVelocity = rigidbody2D.velocity;
             //Mover al slime al objetivo marcado
             //  transform.position = Vector2.MoveTowards(transform.position, last, velocidad * Time.deltaTime);
             test = last;

             //rigidbody2D.velocity = (test - transform.position) * velocidad;


             */



        }

        else
        {
            
        }

    }

    public void Desbuguear()
    {

    }

    public void DesactivarMovimiento()
    {
        firstIAttack = true;
        movimiento = false;


    }

    public void ActivarMovimiento()
    {
       
        igualx = false;
        igualy = false;
        last = objetivo.transform.position; //Marcar objetivo

        movimiento = true;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {




    }
}
