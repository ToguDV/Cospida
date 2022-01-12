using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float velocidad;
    AnimatorClipInfo[] clipInfo;
    Rigidbody2D rb2d;
    Animator animatorr;
    Vector2 movement;
    bool canDash;
    public float duracion;

    private void Update()
    {
        if (canDash)
        {
            Mover();
        }
    }
    public void Dashear(Rigidbody2D rb, Animator animator)
    {
        Invoke("DetenerDash", duracion);
        canDash = false;
        animatorr = animator;
        rb2d = rb;
       
        switch (GetCurrentClipName(animator))
        {
            case "ataqueCorriendoBajo":
            case "caminarAtras":
            case "idleAtras":
                print("dash abajo");
                movement = Vector2.down * velocidad;

                break;

            case "ataqueCorriendoA":
            case "caminarAdelante":
            case "idleAdelante":
                movement = Vector2.up * velocidad;


                break;

            case "ataqueCorriendoD":
            case "caminarDerecha":
            case "idleDerecha":
                movement = Vector2.right * velocidad;


                break;

            case "ataqueCorriendoI":
            case "CaminarIzquierda":
            case "idleIzquierdo":
                movement = Vector2.left * velocidad;


                break;

            
            default:

                break;
               

        }
        canDash = true;
    }

    void Mover()
    {
        rb2d.velocity = movement;
    }

    public string GetCurrentClipName(Animator animator)
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;

    }

    public void DetenerDash()
    {
        rb2d.velocity = Vector2.zero;
        animatorr.SetBool("isDash", false);
        PlayerController.canMove = true;
        PlayerController.canAttack = true;
        canDash = false;
    }
}
