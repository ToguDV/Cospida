﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoBanditKnife : StateMachineBehaviour
{
    private BanditKnifeController banditKnifeController;
    public Spawner spawner;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAtacking", false);
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        banditKnifeController = animator.gameObject.GetComponent<BanditKnifeController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponent<EnemigoBasico>().vida <= 0)
        {
            animator.gameObject.tag = "Untagged";
            animator.SetBool("isDead", true);
            banditKnifeController.setProtected(true);
            
        }
        if (stateInfo.normalizedTime >= 1)
        {
            animator.SetBool("isDamaged", false);


        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        banditKnifeController.setRigidBody2D(Vector2.zero);
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