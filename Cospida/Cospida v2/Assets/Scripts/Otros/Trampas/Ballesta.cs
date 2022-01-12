using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour
{
    public Animator animator;
    public GameObject flecha;
    public GameObject pointShoot;
    public float delay;
    public void Disparar()
    {
        
        animator.SetBool("Shooting", true);
    }

    public void ShootWithDelay()
    {
        Invoke("Disparar", delay);
    }

    public void SoltarFlecha()
    {
        Instantiate(flecha, pointShoot.transform.position, pointShoot.transform.rotation);
    }
}
