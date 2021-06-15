using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleMago : StateMachineBehaviour
{
    int random = 2;
    public float maxDuration = 1f, minDuration = 1.5f;
    float duration = 0;
    float time;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("select", 2); //En 2 para que no active ni el 0 ni el 1
        time = 0;
        duration = Random.Range(maxDuration, minDuration);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if(time >= duration)
        {
            time = 0f;
            
            animator.SetBool("isSpelling", true);
            random = Random.Range(0, 2);
            animator.SetInteger("select", random);

               
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
