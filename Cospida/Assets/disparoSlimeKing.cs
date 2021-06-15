using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoSlimeKing : StateMachineBehaviour
{
    public GameObject posDisparo;
    public GameObject proyectil;
    public float initDelay = 3.5f;
    public float ratio;
    float timer;
    float timer2;
    public float duration = 6;
    public AudioClip sonido;
    AudioSource audioSource;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = GameObject.Find("Slime king").GetComponent<AudioSource>();
        audioSource.clip = sonido;
        timer2 = 0;
        timer = duration;
        posDisparo = GameObject.Find("posDisparoSking");
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer2 += Time.deltaTime;
        if (timer2 >= initDelay)
        {
            timer += Time.deltaTime;

            if (timer >= ratio)
            {
                audioSource.Play();
                Instantiate(proyectil, posDisparo.transform.position, Quaternion.identity);
                timer = 0;
            }

            if(timer2 >= duration)
            {
                animator.SetBool("isDisparando", false);
            }
        }

        
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
