using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AxeLaunch : MonoBehaviour
{
    GameObject player;
    public Rigidbody2D rb2d;
    Vector3 lastVelocity;
    public float speed;
    public float maxVelocity;
    public float fuerza;
    public float fuerzaEmpuje;
    public float pushLimit;
    private Vector3 velocidadAnterior;
    public AIPath ai;
    public AIDestinationSetter aIDestinationSetter;
    bool onceCollision;
    EnemigoConMovimiento enemigoConMovimiento;
    GameObject bossBandit;

    private void Awake()
    {
        ai.enabled = false;
    }

    void Start()
    {
        onceCollision = false;
        enemigoConMovimiento = GameObject.Find("Boss bandido").GetComponentInChildren<EnemigoConMovimiento>();
        bossBandit = GameObject.Find("Boss bandido");
        player = GameObject.Find("Player");
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, LayerMask.GetMask("Player"));

        if (hit2D)
        {
            Debug.LogWarning(hit2D.transform.name);
            Debug.LogWarning(hit2D.point);
        }

        rb2d.velocity = (player.transform.position - transform.position) * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (onceCollision)
        {
            ai.enabled = true;
            aIDestinationSetter.target = bossBandit.transform;
            if (ai.reachedDestination)
            {
                CorriendoBanditBoss.isRunAttack2 = false;
                enemigoConMovimiento.SetAnimatorBool("Attack2", false);
                Destroy(gameObject);
            }

        }
        lastVelocity = rb2d.velocity;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onceCollision = true;
        velocidadAnterior = rb2d.velocity;
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb2d.velocity = direction * Mathf.Max(speed, 0f);
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy") && EnemigoBasico.canDamage)
        {
            EnemigoBasico.canDamage = false;
            player.GetComponent<PlayerController>().Herirse(fuerza, fuerzaEmpuje, velocidadAnterior, pushLimit);
        }
    }

}
