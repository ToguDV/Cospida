using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaksController : MonoBehaviour
{
    public Animator animator;
    public bool manual;
    public float timeDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul") && !manual)
        {
            Invoke("ManualActivation", timeDelay);
        }
    }

    public void ManualActivation()
    {
        animator.SetBool("isActive", true);
    }


    public void ManualDesactivation()
    {
        animator.SetBool("isActive", false);
    }
}
