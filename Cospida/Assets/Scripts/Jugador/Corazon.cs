using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    public int index;
    Animator animator;
    public static bool PasarOtro = false;
    public LifeManager lifeManager;
    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    public void PerderMitad()
    {

        animator.SetBool("isHalf", true);


    }

    public void PerderOtraMitad()
    {


        animator.SetBool("isEmpty", true);

    }

    public void PerderTodo()
    {

        animator.SetBool("isEmpty", true);



    }

    public void Morir()
    {

        LifeManager.actualizar = false;
    }



    public void Damage(float damage)
    {

        resetearCuracion();

        if (AnimationPlaying("vacio"))
        {
            if (index > 1) //Si no es el último corazón
            {
                LifeManager.ultimo--;
                lifeManager.DamageCorazones(damage);

            }
        }

        if (AnimationPlaying("lleno"))
        {
            if (damage == 0.5)
            {
                //PERDER MITAD DE CORAZÓN
                animator.SetBool("isHalf", true);
            }

            else if (damage == 1f)
            {
                if (index > 1)
                {
                    LifeManager.ultimo--;
                }
                //PERDER CORAZÓN ENTERO
                animator.SetBool("isEmpty", true);
            }
        }

        if (AnimationPlaying("mitad"))
        {
            if (index > 1)
            {
                LifeManager.ultimo--;
            }
            if (damage == 0.5)
            {
                //PERDER OTRA MITAD DE CORAZÓN
                animator.SetBool("isEmpty", true);
            }

            else if (damage == 1f)
            {

                //PERDER OTRA MITAD DE CORAZÓN
                animator.SetBool("isEmpty", true);
                if (index > 1)//Si no es el último corazón
                {
                    //Restarle la otra mitad que falta al corazón de la izquierda

                    lifeManager.DamageCorazones(0.5f);
                }


            }
        }


    }

    public void Curar(float curar)
    {

        if (AnimationPlaying("lleno"))
        {
            if (index < Player.vidaMax)
            {
                LifeManager.ultimo++;
                lifeManager.CurarCorazones(curar);
                resetearDamage();
            }
        }



        if (AnimationPlaying("vacio"))
        {
            resetearDamage();
            if (curar == 0.5f)
            {
                //CURAR MITAD IZQUIERDA
                animator.SetBool("is_Half", true);
                return;
            }

            else if (curar == 1f)
            {
                //CURAR TODO
                animator.SetBool("is_Full", true);
            }
        }

        if (AnimationPlaying("mitad"))
        {
            //AQUÍ ESTÁ EL ERROR
            //NO SE PUEDE AUMENTAR EN TODOS PORQUE SOBREPASA EL LÍMITE DERECHO
            if (index < Player.vidaMax)
            {
                LifeManager.ultimo++;
            }
            resetearDamage();
            if (curar == 0.5f)
            {
                //CURAR MITAD DERECHA
                animator.SetBool("is_Half", true);
            }

            else if (curar == 1f)
            {
                //CURAR MITAD DERECHA
                animator.SetBool("is_Half", true);


                // PASAR LA OTRA MITAD AL CORAZÓN SIGUIENTE SIEMPRE Y CUANDO NO SE ESTÉ EN EL ÚLTIMO CORAZÓN

                if (index < Player.vidaMax)
                {

                    lifeManager.CurarCorazones(0.5f);
                }

            }
        }



    }


    private bool AnimationPlaying(string animacion) //SABER SI SE ESTÁ EJECUTANDO UNA ANIMACIÓN
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName(animacion))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void resetearDamage()
    {
        animator.SetBool("isEmpty", false);
        animator.SetBool("isHalf", false);

    }

    public void resetearCuracion()
    {
        animator.SetBool("is_Full", false);
        animator.SetBool("is_Half", false);
    }
}
