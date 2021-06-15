
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemigoBasico : MonoBehaviour
{
    public float vida;
    public float fuerza; //Daño que inflige
    protected Animator animator;
    protected GameObject objetivo; //Objetivo a seguir o atacar
    protected Rigidbody2D rigidbody2D;
    public float velocidad = 1f; //Velocidad de movimiento
    public float fuerzaEmpuje;
    public float empujado = 2;
    public static bool canDamage = true;
    int posOnda;
    OndaExpansiva ondaExpansiva;
    public int fragilidad = 1;
    protected Vector2 pushVelocity;
    protected Animator animPlayer;
    protected Vector2 movement;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void Inicial() //Se pone en el método start de quien herede esta clase.
    {

        
        objetivo = GameObject.FindGameObjectWithTag("Player"); //Se obtiene al jugador como objetivo
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animPlayer = objetivo.GetComponent<Animator>();
    }

    public virtual void Movimiento()
    {
        
    }

    public void Herirse() //Le resta vida.
    {
        animator.SetBool("isDamaged", true );
         float damage= (Player.fuerza * fragilidad); /*  El daño se calcula con el porcentaje de daño (Fragilidad) que puede recibir el enemigo y la fuerza
                                                      *  que tiene el jugador.
        
                                                     
                                                     */

        

        vida -= damage;

        
            rigidbody2D.velocity = empujado * new Vector2(animPlayer.GetFloat("x"), animPlayer.GetFloat("y"));
        




    }

    public void Herir(PlayerController playerController)
    {
        
        if (canDamage) {

          
            playerController.Herirse(fuerza, fuerzaEmpuje, pushVelocity);
            canDamage = false;
            
        }


}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque"))
        {

            ondaExpansiva = collision.gameObject.GetComponent<OndaExpansiva>();
            Destroy(collision.gameObject);
           
            Herirse();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            
            Herir(collision.gameObject.GetComponentInParent<PlayerController>());
        }


    }

  

    public virtual GameObject GetObjetivo()
    {
        return objetivo;
    }
}
