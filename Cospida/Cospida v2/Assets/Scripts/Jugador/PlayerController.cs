using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Publics
    public static int posOnda;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GameObject[] posicionesOnda;
    public GameObject onda;
    public int nParpadeos;
    public float frecuenciaParpadeos;
    public Color transparente;
    public Color normal;
    public static bool isMobile = true;
    public SoundPlayer soundPlayer;
    public SonidoPasos sonidoPasos;
    public GameObject EffectDamage;
    public float delayAttack = 3f;
    public PlayerDash playerDash;


    //Privates
    LifeManager lifeManager;
    Vector2 movement;
    Player player;
    AnimatorClipInfo[] clipInfo;
    Joystick joystick;
    public static bool canMove = true;
    public static bool canAttack = true;
    public static bool canDash = true;
    public static bool isOnCinematic = false;
    Vector2 tempEmpujado;
    Sacudida sacudida;
    public float segActivateInicial = 2;
    
    void Start()
    {
        lifeManager = GameObject.Find("Corazones").GetComponent<LifeManager>();
        if (isMobile)
        {
            joystick = GameObject.Find("Floating Joystick").GetComponent<Joystick>();
        }
        canAttack = false;
        canMove = false;
        Invoke("ActivarJugador", segActivateInicial);
        EnemigoBasico.canDamage = true;
        sacudida = GameObject.Find("Sacudida").GetComponent<Sacudida>();
        EnemigoBasico.canDamage = true;
        player = GetComponent<Player>();


    }

    public void ActivarJugador()
    {
        if (!isOnCinematic)
        {
            canAttack = true;
            canMove = true;
        }
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

        if (!isMobile)
        {
            Dashear();
        }

    }

    public void Dashear()
    {
        if (canDash)
        {
            //SI PUEDE HACER DASH
            if (!animator.GetBool("isDead") && !animator.GetBool("isAttack") && !animator.GetBool("isDash") && !animator.GetBool("damage"))
            {
                //EJECUCIÓN DE DASH
                if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.JoystickButton0) || isMobile)
                {
                    playerDash.Dashear(rigidbody2D, animator);
                    canMove = false;
                    animator.SetBool("isDash", true);
                    animator.SetFloat("magnitude", 0f);
                    canAttack = false;

                }
            }
        }
        
    }

    private void Move()
    {

        if (!pause.active)
        {


            if (isMobile)
            {
                movement.x = joystick.Horizontal;
                movement.y = joystick.Vertical;
            }
            else
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }


            animator.SetFloat("magnitude", movement.magnitude);

            if (movement.magnitude == 0)
            {

            }

            else
            {
                Vector2 tempMov;
                tempMov.x = Mathf.RoundToInt(movement.x);
                tempMov.y = Mathf.RoundToInt(movement.y);

                animator.SetFloat("x", tempMov.x);
                animator.SetFloat("y", tempMov.y);
            }

            Player.empuje = movement;
        }
    }

    float magnitudSacudida;

    private void FixedUpdate()
    {
        if (canMove)
        {
            rigidbody2D.velocity = movement * player.velocidad;
        }
    }

    private void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton3)) && !animator.GetBool("isAttack") && !animator.GetBool("damage"))
        {

            if (canAttack)
            {
                attackFinal();
            }



        }
    }

    private void ActivateAttack()
    {
        if (!isOnCinematic)
        {
            canAttack = true;
        }
        
    }

    public void attackFinal()
    {
        //Desactivar ataque
        canAttack = false;
        //Empezar a activar ataque
        Invoke("ActivateAttack", delayAttack);
        //Sonido de la espada
        soundPlayer.attack();
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

    public string GetCurrentClipName()
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
    }

    public void Herirse(float fuerza, float fuerzaEmpuje, Vector2 pushVelocity, float limit)
    {
        Instantiate(EffectDamage, transform.position, transform.rotation);
        //Sonido de daño
        soundPlayer.hurtPlayer();

        canMove = false;
        tempEmpujado = pushVelocity * fuerzaEmpuje;

        if (tempEmpujado.x > limit)
        {
            tempEmpujado.x = limit;
        }

        if (tempEmpujado.x < -limit)
        {
            tempEmpujado.x = -limit;
        }

        if (tempEmpujado.y > limit)
        {
            tempEmpujado.y = limit;
        }

        if (tempEmpujado.y < -limit)
        {
            tempEmpujado.y = -limit;
        }



        rigidbody2D.velocity = tempEmpujado;




        sacudida.sacudirCamera(3, 0.01f);

        if (Player.vida > 0)
        {


            lifeManager.DamageCorazones(fuerza);
            animator.SetBool("damage", true);

            Player.vida -= fuerza;
            if (Player.vida > 0)
            {
                StartCoroutine(Parpadear());
            }

            else
            {

                Invoke("Morir", 3f);
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
                if (animator.GetBool("isDash"))
                {

                }

                else
                {
                    if (!isOnCinematic)
                    {
                        canMove = true;
                    }
                    
                }

            }

            else
            {

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

    public void Morir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void pisar()
    {
        
    }

}
