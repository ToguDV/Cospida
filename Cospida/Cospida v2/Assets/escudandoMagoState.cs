using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudandoMagoState : StateMachineBehaviour
{
    MagoController mago;
    Vector3 temp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mago = animator.gameObject.GetComponent<MagoController>();
        animator.SetInteger("select", 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        temp = new Vector3(mago.GetObjetivo().transform.position.x - animator.transform.position.x, mago.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp.x = Mathf.Round(temp.x);
        temp.y = Mathf.Round(temp.y);
        animator.SetFloat("x", temp.x);
        animator.SetFloat("y", temp.y);


        if (stateInfo.normalizedTime >= 1)
        {
            animator.SetBool("isSpelling", false);
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
