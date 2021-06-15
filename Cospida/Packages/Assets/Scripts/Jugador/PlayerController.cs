using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    //Publics
    public static int posOnda;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GameObject[] posicionesOnda;
    public GameObject onda;
    public LifeManager lifeManager;
    public int nParpadeos;
    public float frecuenciaParpadeos;
    public Color transparente;
    public Color normal;

    //Privates
    Vector2 movement;
    Player player;
    AnimatorClipInfo[] clipInfo;
    bool canMove = true;
    Vector2 tempEmpujado;
    void Start()
    {
        player = GetComponent<Player>();

    }

    private void Update()
    {
        if (canMove && !animator.GetBool("isDead"))
        {
            Move();
        }

        if (!animator.GetBool("isDead"))
        {
            Attack();
        }
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        animator.SetFloat("magnitude", movement.magnitude);

        if (movement.magnitude == 0)
        {

        }

        else
        {

            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
        }

        Player.empuje = movement;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rigidbody2D.velocity = movement * player.velocidad;
        }


    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isAttack"))
        {
            animator.SetBool("isAttack", true);
            switch (GetCurrentClipName())
            {
                case "ataqueCorriendoBajo":
                case "caminarAtras":
                case "idleAtras":
                    posOnda = 1;

                    break;

                case "ataqueCorriendoA":
                case "caminarAdelante":
                case "idleAdelante":
                    posOnda = 2;

                    break;

                case "ataqueCorriendoD":
                case "caminarDerecha":
                case "idleDerecha":
                    posOnda = 3;


                    break;

                case "ataqueCorriendoI":
                case "CaminarIzquierda":
                case "idleIzquierdo":
                    posOnda = 4;

                    break;

                default:

                    break;
            }


            try
            {
                Instantiate(onda, posicionesOnda[posOnda - 1].transform.position, posicionesOnda[posOnda - 1].transform.rotation);
            }
            catch (System.Exception)
            {

                Debug.LogError("Se bugueo la onda, posOnda -1 no puede ser menor a 0 ni mayor a 3, posOnda actual es igual a: " + posOnda);
                Debug.LogError("posOnda:" + posOnda);
            }




        }
    }

    public string GetCurrentClipName()
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
    }

    public void Herirse(float fuerza, float fuerzaEmpuje, Vector2 pushVelocity)
    {
        print("push y" + pushVelocity.y);
        print("push x" + pushVelocity.x);
        canMove = false;
        rigidbody2D.velocity = tempEmpujado;
        tempEmpujado = pushVelocity * fuerzaEmpuje;

        if (Player.vida > 0)
        {


            lifeManager.DamageCorazones(fuerza);
            animator.SetBool("damage", true);

            Player.vida -= fuerza;
            if (Player.vida > 0)
            {
                StartCoroutine(Parpadear());
            }
        }

    }

    public IEnumerator Parpadear()
    {

        for (int i = 0; i < nParpadeos; i++)
        {

            GetComponent<SpriteRenderer>().color = transparente;
            yield return new WaitForSeconds(frecuenciaParpadeos);
            if (Player.vida > 0)
            {
                canMove = true;
            }

            else
            {
                rigidbody2D.velocity = Vector2.zero;
            }
            GetComponent<SpriteRenderer>().color = normal;
            yield return new WaitForSeconds(frecuenciaParpadeos);

        }

        GetComponent<SpriteRenderer>().color = normal;
        if (Player.vida > 0)
        {
            EnemigoBasico.canDamage = true;
        }

    }



}
