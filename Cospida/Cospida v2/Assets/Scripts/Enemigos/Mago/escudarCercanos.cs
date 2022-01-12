using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudarCercanos : MonoBehaviour
{
    public Animator animator;
    public GameObject escudo;
    public GameObject main;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (animator.GetInteger("select") == 1 && collision.gameObject.CompareTag("Enemy") && collision.gameObject != main)
        {
            if (!collision.gameObject.GetComponent<EnemigoBasico>().getProtected())
            {
                GameObject enemigo;
                enemigo = collision.gameObject;
                Instantiate(escudo, enemigo.transform);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (animator.GetInteger("select") == 1 && collision.gameObject.CompareTag("Enemy") && collision.gameObject != main)
        {
            if (!collision.gameObject.GetComponent<EnemigoBasico>().getProtected())
            {
                GameObject enemigo;
                enemigo = collision.gameObject;
                Instantiate(escudo, Vector3.zero , Quaternion.identity, enemigo.transform);
            }
        }
    }

}
