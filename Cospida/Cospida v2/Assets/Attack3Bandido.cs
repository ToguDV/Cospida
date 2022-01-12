using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Bandido : StateMachineBehaviour
{

    private EnemigoConMovimiento enemigoConMovimiento;
    public float durAnticip = 1f;
    float time;
    public GameObject efectoAtaque3;
    bool first = true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.setProtected(true);
        time = 0f;
        first = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if (time >= durAnticip && first)
        {
            first = false;
            Instantiate(efectoAtaque3, animator.transform.position, Quaternion.identity);
            enemigoConMovimiento.collider2D.radius = 6f;

        }

        if (stateInfo.normalizedTime >= 0.32f)
        {
            enemigoConMovimiento.setProtected(false);
            enemigoConMovimiento.collider2D.radius = 0.58f;
        }



            if (stateInfo.normalizedTime >= 1)
        {
            animator.SetBool("Attack3", false);
            enemigoConMovimiento.collider2D.radius = 0.58f;
            enemigoConMovimiento.setProtected(true);
            animator.SetBool("isMiss", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack3", false);
        enemigoConMovimiento.collider2D.radius = 1.5f;
        enemigoConMovimiento.setProtected(true);
        animator.SetBool("isMiss", false);
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
