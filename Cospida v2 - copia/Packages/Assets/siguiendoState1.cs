using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class siguiendoState1 : StateMachineBehaviour
{
    GameObject objetivo;
    public float dejarDistancia;
    EnemigoBasico enemigoScript;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoScript = animator.gameObject.GetComponent<EnemigoBasico>();
        objetivo = enemigoScript.GetObjetivo();
        animator.SetBool("isFollowing", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, objetivo.transform.position) > dejarDistancia)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, objetivo.transform.position,  enemigoScript.velocidad * Time.deltaTime);
        }

        else
        {
            animator.SetBool("isFollowing", false);
            animator.SetBool("isAttacking", true);
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
