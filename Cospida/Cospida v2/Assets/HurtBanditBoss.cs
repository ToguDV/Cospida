using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBanditBoss : StateMachineBehaviour
{

    float time = 0;
    public float duracion = 3;
    public static int hits;
    EnemigoConMovimiento enemigoConMovimiento;
    Vector3 temp;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        temp = new Vector3(enemigoConMovimiento.GetObjetivo().transform.position.x - animator.transform.position.x, enemigoConMovimiento.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp.x = Mathf.Round(temp.x);
        temp.y = Mathf.Round(temp.y);
        animator.SetFloat("x", temp.x);
        animator.SetFloat("y", temp.y);
        
        enemigoConMovimiento.setProtected(true);
        hits++;
        time = 0;

        if (hits >= 4 && EnemigoConMovimiento.currentFase >= 2)
        {
            enemigoConMovimiento.aipath.maxSpeed = 15f;
            CorriendoBanditBoss.isRunAttack2 = true;
            enemigoConMovimiento.setProtected(true);



        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        time += Time.deltaTime;
        if (time >= duracion)
        {
            animator.SetBool("isDamaged", false);
            enemigoConMovimiento.setRigidBody2D(Vector2.zero);
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
