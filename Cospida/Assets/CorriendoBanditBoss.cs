using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorriendoBanditBoss : StateMachineBehaviour
{
    private EnemigoConMovimiento enemigoConMovimiento;
    public float acercamiento;
    public string[] nameAttacks;
    private int randomPickAttack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.destination.target = enemigoConMovimiento.GetObjetivo().transform;
        enemigoConMovimiento.aipath.canMove = true;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(animator.gameObject.transform.position, enemigoConMovimiento.GetObjetivo().transform.position) <= acercamiento)
        {
            animator.SetBool("Attack1", true);
        }

        if(HurtBanditBoss.hits >= 4)
        {
            animator.SetBool("Attack2", true);

            HurtBanditBoss.hits = 0;
        }


        enemigoConMovimiento.Movimiento();
        if (enemigoConMovimiento.combed)
        {
            enemigoConMovimiento.combed = false;
            animator.SetBool("Attack3", true);
        }
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento.aipath.canMove = false;
        animator.SetBool("isMove", false);
    }
}
