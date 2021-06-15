using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class SlimeKingController : EnemigoBasico
{
    AIPath aipath;
    public Slider[] barrasVida;
    public GameObject[] lifeGameobject;
    public static int hits;
    public Sacudida sacudida;
    public static bool canCarga = true;
    public GameObject escudo;
    float maxVida;
    void Start()
    {
        FaseController.bossFase = 0;
        maxVida = 15;
        escudo.SetActive(true);
        vida = maxVida;
        canCarga = true;
        sacudida = GameObject.Find("Sacudida").GetComponent<Sacudida>();
        Inicial();
        aipath = GetComponentInParent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Herirse() //Le resta vida.
    {


        aipath.canMove = false;
        animator.SetBool("isDamaged", true);
        float damage = (Player.fuerza * fragilidad); /*  El daño se calcula con el porcentaje de daño (Fragilidad) que puede recibir el enemigo y la fuerza
                                                      *  que tiene el jugador.
        
                                                     
                                                     */



        vida -= damage;

        rigidbody2D.velocity = empujado * new Vector2(animPlayer.GetFloat("x"), animPlayer.GetFloat("y"));
        barrasVida[FaseController.bossFase].value = vida;
        if (barrasVida[FaseController.bossFase].value <= 0 && FaseController.bossFase != 2)
        {
            lifeGameobject[FaseController.bossFase].SetActive(false);
            vida = maxVida;
            FaseController.bossFase++;
            lifeGameobject[FaseController.bossFase].SetActive(true);
        }

        if(FaseController.bossFase == 3)
        {
            vida = 0;
        }

        if(vida <= 0)
        {

            animator.SetBool("isDeath", true);
            
            coreGanar.Ganar(2, "Mazmorra");
        }




    }

    public override void Herir(PlayerController playerController)
    {

        if (canDamage)
        {


            playerController.Herirse(fuerza, fuerzaEmpuje, aipath.velocity, pushLimit);
            canDamage = false;

        }



    }

    public void InvocarDesaturdimiento(float duration)
    {
        Invoke("Desaturdimiento", duration);
    }

    private void Desaturdimiento()
    {
        animator.SetBool("isAturdido", false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo") && animator.GetBool("isCharge"))
        {

            animator.SetBool("isAturdido", true);
            sacudida.sacudirCamera(5, 1f);
        }

        if (collision.gameObject.CompareTag("Player") && animator.GetBool("isCharge"))
        {

            animator.SetBool("isCharge", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstaculo") && animator.GetBool("isCharge"))
        {

            animator.SetBool("isAturdido", true);
            sacudida.sacudirCamera(5, 1f);
        }

        if (collision.gameObject.CompareTag("Player") && animator.GetBool("isCharge"))
        {
            animator.SetBool("isCharge", false);

        }
    }


    public void OnCollisionStay2D(Collision2D collision)
    {

        /*  if (collision.gameObject.CompareTag("Obstaculo") && animator.GetBool("isCharge"))
          {
              canCarga = false;
              animator.SetBool("isAturdido", true);
              sacudida.sacudirCamera(5, 1f);
          }
        */

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            canCarga = true;
        }
    }

    public override void setProtected(bool protection)
    {
        isProtected = protection;

        escudo.SetActive(protection);
    }



}
