using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDistanceDetection : MonoBehaviour
{
    public EnemigoBasico enemigo;
    public float rangeDetection;
    public GameObject main;
    public bool isNear;
    public string followName = "isPatrolling";
    Collider2D col;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, enemigo.GetObjetivo().transform.position) <= rangeDetection)
        {
            isNear = true;
            enemigo.getAnimator().SetBool(followName, true);
        }

        else
        {
            isNear = false;
        }
        transform.position = main.transform.position;

        //col.IsTouching
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isNear)
        {
            enemigo.getAnimator().SetBool(followName, false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isNear)
        {
            enemigo.getAnimator().SetBool("isShooting", false);

            enemigo.getAnimator().SetBool(followName, true);

        }

    }

    
}
