using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaksController : MonoBehaviour
{
    public Animator animator;
    public bool manual;
    public float timeDelay;
    public bool isPlayer;
    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();    
    }

    void Start()
    {
        isPlayer = false;
        if (manual)
        {
            ManualActivation();
            TriggerSetter(false);
        }
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul") && !manual)
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playervul") && !manual)
        {
            isPlayer = false;
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

    public void TriggerSetter(bool value)
    {
        collider.isTrigger = value;
    }
}
