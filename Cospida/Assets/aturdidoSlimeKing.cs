using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aturdidoSlimeKing : StateMachineBehaviour
{
    public float duration;
    public AudioClip sonido;
    AudioSource audioSource;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = GameObject.Find("audioSecundario").GetComponent<AudioSource>();
        audioSource.clip = sonido;
        if (!animator.GetBool("isDamageAturdido"))
        {
            audioSource.Play();
        }
        
        animator.SetBool("isCharge", false);
        animator.SetBool("isDamageAturdido", true);
        animator.gameObject.GetComponent<SlimeKingController>().setProtected(false);
        animator.gameObject.GetComponent<SlimeKingController>().InvocarDesaturdimiento(duration);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
 

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("isDamageAturdido"))
        {
            audioSource.Stop();
        }
            
    }

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
