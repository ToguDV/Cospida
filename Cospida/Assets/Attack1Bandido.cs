using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1Bandido : StateMachineBehaviour
{


    private EnemigoConMovimiento enemigoConMovimiento;
    AnimatorClipInfo[] clipInfo;
    float time;
    public float delayFinish;
    int tempAttackPos;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delayFinish = 2f;
        tempAttackPos = 0;
        time = 0;
        clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.setProtected(false);
        Debug.Log("Ataque 1 inicializado");
        delayFinish += 0.4f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        
        if (stateInfo.normalizedTime >= 0.7f)
        {
            
            if (animator.GetFloat("x") == 0 && animator.GetFloat("y") == 1)
            {
                tempAttackPos = 0;
                enemigoConMovimiento.attack1Positions[0].SetActive(true);
            }

            else if (animator.GetFloat("x") == 0 && animator.GetFloat("y") == -1)
            {
                tempAttackPos = 1;
                enemigoConMovimiento.attack1Positions[1].SetActive(true);
            }

            else if (animator.GetFloat("x") == 1 && animator.GetFloat("y") == 0)
            {
                tempAttackPos = 2;
                enemigoConMovimiento.attack1Positions[2].SetActive(true);
            }

            else if (animator.GetFloat("x") == -1 && animator.GetFloat("y") == 0)
            {
                tempAttackPos = 3;
                enemigoConMovimiento.attack1Positions[3].SetActive(true);
            }

        }


        if(stateInfo.normalizedTime >= 1)
        {
            enemigoConMovimiento.attack1Positions[tempAttackPos].SetActive(false);
        }

        if(time >= delayFinish)
        {
            animator.SetBool("Attack1", false);
            
        }

        if (enemigoConMovimiento.combed)
        {
            enemigoConMovimiento.combed = false;
            animator.SetBool("Attack3", true);
            animator.SetBool("Attack1", false);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento.setProtected(true);
        animator.SetBool("Attack1", false);
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
