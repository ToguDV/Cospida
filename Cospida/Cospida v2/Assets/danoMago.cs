using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoMago : StateMachineBehaviour
{
    private MagoController mago;
    public Spawner spawner;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("select", 0);
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        mago = animator.gameObject.GetComponent<MagoController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponent<EnemigoBasico>().vida <= 0)
        {
            animator.gameObject.tag = "Untagged";
            animator.SetBool("isDead", true);
            mago.setProtected(true);
        }
        if (stateInfo.normalizedTime >= 1)
        {
            animator.SetBool("isDamaged", false);


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
