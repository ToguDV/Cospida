﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBanditBoss : StateMachineBehaviour
{
    public float duracion = 5f;
    float time;
    private EnemigoConMovimiento enemigoConMovimiento;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.aipath.canMove = false;
        time = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if(time >= duracion)
        {
            animator.SetBool("isMove", true);
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