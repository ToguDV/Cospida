using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoDash : MonoBehaviour
{
    public GameObject efectoDashObj;
    public Animator animator;
    public float ratio = 0.3f;
    float timer;
    GameObject currentEfectoDashObj;
    public string animatorDash = "isDash";
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (animator.GetBool(animatorDash) && timer >= ratio)
        {
            currentEfectoDashObj = Instantiate(efectoDashObj, transform.position, transform.rotation);
            currentEfectoDashObj.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            timer = 0;
        }
    }
}
