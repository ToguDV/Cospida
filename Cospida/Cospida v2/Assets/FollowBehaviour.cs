using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowBehaviour : StateMachineBehaviour
{
    private BanditKnifeController banditKnifeController;
    RaycastHit2D hit;
    public float randomRatio;
    float time;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0f;
        banditKnifeController = animator.gameObject.GetComponent<BanditKnifeController>();
        banditKnifeController.destination.target = banditKnifeController.GetObjetivo().transform;
        banditKnifeController.aipath.canMove = true;
    }



    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if (time >= randomRatio)
        {
            time = 0;

        }
        banditKnifeController.Movimiento();

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        banditKnifeController.aipath.canMove = false;
        animator.SetBool("isFollowing", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
