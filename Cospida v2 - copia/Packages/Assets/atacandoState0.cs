﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacandoState0 : StateMachineBehaviour
{
 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   // {
     
   // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    

        if (stateInfo.normalizedTime >= 1)
        {
            animator.SetBool("isAttack", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  



    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
    }
}
