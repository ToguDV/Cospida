using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDropper : MonoBehaviour
{
    public Animator animator;
    public GameObject posArrow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detectado trigger");
        if (collision.gameObject.CompareTag("Playervul"))
        {
            animator.SetBool("isAttack", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Detectado colision");
        if (collision.gameObject.CompareTag("Playervul"))
        {
            animator.SetBool("isAttack", true);
        }
    }
}
