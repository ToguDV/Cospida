
using UnityEngine;

public class EnemigoBasico : MonoBehaviour
{
    public GameObject damageEffect;
    public float vida;
    public AudioClip damageSound;
    public AudioSource audioSource;
    public float fuerza; //Daño que inflige
    protected Animator animator;
    protected GameObject objetivo; //Objetivo a seguir o atacar
    protected Rigidbody2D rigidbody2D;
    public float velocidad = 1f; //Velocidad de movimiento
    public float fuerzaEmpuje;
    public float empujado = 2;
    public static bool canDamage = true;
    public float pushLimit = 25;
    int posOnda;
    OndaExpansiva ondaExpansiva;
    public int fragilidad = 1;
    protected Vector2 pushVelocity;
    protected Animator animPlayer;
    protected Vector2 movement;
    protected bool isProtected;
    protected bool movimiento = false;
    public bool Slimeking;

    public void Inicial() //Se pone en el método start de quien herede esta clase.
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(Slimeking)
        {
            rigidbody2D = GetComponentInParent<Rigidbody2D>();

        }
        objetivo = GameObject.FindGameObjectWithTag("Player"); //Se obtiene al jugador como objetivo
        animator = GetComponent<Animator>();
       
        animPlayer = objetivo.GetComponent<Animator>();
    }

    public virtual void Movimiento()
    {
        
    }

    public virtual void Herirse() //Le resta vida.
    {
        audioSource.clip = damageSound;
        audioSource.Play();

        Instantiate(damageEffect, transform.position, Quaternion.identity);

        animator.SetBool("isDamaged", true );
        float damage = (Player.fuerza * fragilidad); /*  El daño se calcula con el porcentaje de daño (Fragilidad) que puede recibir el enemigo y la fuerza
                                                      *  que tiene el jugador.                                            
                                                     */
        vida -= damage;

        rigidbody2D.velocity = empujado * new Vector2(animPlayer.GetFloat("x"), animPlayer.GetFloat("y"));
    }

    public virtual void Herir(PlayerController playerController)
    {
        
        if (canDamage) {

          
            playerController.Herirse(fuerza, fuerzaEmpuje, pushVelocity, pushLimit);
            canDamage = false;

        }



    }

    public virtual void startMovement()
    {
       
    }

    public virtual void ActivarMovimiento()
    {

    }

    public virtual void DesactivarMovimiento()
    {

    }

    public void setRigidBody2D(Vector2 velocity)
    {
        rigidbody2D.velocity = velocity;
    }
     

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque") && !gameObject.CompareTag("Untagged"))
        {

            ondaExpansiva = collision.gameObject.GetComponent<OndaExpansiva>();
            Destroy(collision.gameObject);

            if (!isProtected) {
                DesactivarMovimiento();
                rigidbody2D.velocity = Vector2.zero;
                Herirse();
                
            }
        }

        if (collision.gameObject.CompareTag("Playervul") && gameObject.CompareTag("Enemy"))
        {
            print("pegale we");
            Herir(collision.gameObject.GetComponentInParent<PlayerController>());
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque") && gameObject.CompareTag("Enemy"))
        {

            ondaExpansiva = collision.gameObject.GetComponent<OndaExpansiva>();
            Destroy(collision.gameObject);

            if (!isProtected)
            {
                DesactivarMovimiento();
                rigidbody2D.velocity = Vector2.zero;
                Herirse();

            }
        }

        if (collision.gameObject.CompareTag("Playervul") && gameObject.CompareTag("Enemy"))
        {
            Debug.LogWarning("PEGALEEEEE");
            Herir(collision.gameObject.GetComponentInParent<PlayerController>());
        }


    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul") && gameObject.CompareTag("Enemy"))
        {
            print("pegale we");
            Herir(collision.gameObject.GetComponentInParent<PlayerController>());
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul") && gameObject.CompareTag("Enemy"))
        {
            print("pegale we");
            Herir(collision.gameObject.GetComponentInParent<PlayerController>());
        }
    }

    public virtual Rigidbody2D GetRigidBody2D()
    {
        return rigidbody2D;
    }
    public virtual GameObject GetObjetivo()
    {
        return objetivo;
    }

    public virtual void setProtected(bool protection)
    {
        isProtected = protection;
    }

    public virtual bool getProtected()
    {
        return isProtected;
    }


    public virtual Animator getAnimator()
    {
        return animator;
    }


}
