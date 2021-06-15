

using UnityEngine;


public class SlimeController : EnemigoBasico
{
    public float frecuencia; //Frecuencia de ataque.
    public float duracion; //(Duración de ataque)

    Vector3 last = Vector3.zero; //Es la última posición obtenida del jugador antes de saltar a atacarlo.
    public Vector3 test;
    public bool igualx, igualy;
    public bool firstIAttack = true;
    public bool transicion = false;
    public static int direccionTransicion = 1;
    bool esquivando;
    bool movimientoDefinitivo = true;
    public float limiteAcercamiento = 1;
    public AudioClip clipJump;
    public AudioClip clipSpawn;
    void Start()
    {
        
        Inicial(); //Se inicializan los componentes heredados. (Este es un método heredado)

        //SONIDO DE SPAWNEO
        audioSource.clip = clipSpawn;
        audioSource.Play();
        if (transicion)
        {
            direccionTransicion *= -1;
            rigidbody2D.velocity = (new Vector2(80 * direccionTransicion, 0));


        }
        frecuencia = Random.Range(frecuencia - 1, frecuencia);

    }

    public override void startMovement()
    {
        //Se inicia el ciclo entre atacar y quedarse quieto.
        InvokeRepeating("ActivarMovimiento", frecuencia, frecuencia);
        InvokeRepeating("DesactivarMovimiento", frecuencia + duracion, frecuencia);
        InvokeRepeating("activarAlerta", frecuencia / 2, frecuencia);
    }

    // Update is called once per frame

    private void LateUpdate()
    {

    }

    void Update()
    {
        
        Movimiento();
       

    }
   
    
    
   
    

    void activarAlerta()
    {
        animator.SetBool("isPreparing", true);
    }

    private void FixedUpdate()
    {
        //Según el tipo de slime para el salto
        if (movimiento && movimientoDefinitivo)
        {
            
            rigidbody2D.velocity = movement * velocidad;
          
        }

        if (esquivando )
        {
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
            movimientoDefinitivo = true;
            if (Vector2.Distance(last, transform.position) <= 1)
            {
                DesactivarMovimiento();
            }







        }

      

    }

    public void Desbuguear()
    {

    }

    public override void DesactivarMovimiento()
    {
        firstIAttack = true;
        movimiento = false;
        movimientoDefinitivo = false;
        animator.SetBool("isPreparing", false);

    }

    public override void ActivarMovimiento()
    {
        
        igualx = false;
        igualy = false;
        last = objetivo.transform.position; //Marcar objetivo

        movimiento = true;
        audioSource.clip = clipJump;
        audioSource.Play();

    }


 

 

 

    public void setProtected(bool value)
    {
        isProtected = value;
    }
}
