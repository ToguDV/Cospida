using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloresTrigg : MonoBehaviour
{
    Animator animator;
    public float time = 1f;
    void Start()
    {
        
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("trigg", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        animator.SetBool("trigg",true);
        Invoke("VolverNormal", time);
    }

    void VolverNormal()
    {
        animator.SetBool("trigg", false);
    }
}
