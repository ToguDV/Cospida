using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2Bandido : StateMachineBehaviour
{
    int tempAttackPos;
    private EnemigoConMovimiento enemigoConMovimiento;
    AnimatorClipInfo[] clipInfo;
    public GameObject axe;
    bool once;
    Vector3 temp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        once = false;
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        temp = new Vector3(enemigoConMovimiento.GetObjetivo().transform.position.x - animator.transform.position.x, enemigoConMovimiento.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp.x = Mathf.Round(temp.x);
        temp.y = Mathf.Round(temp.y);
        animator.SetFloat("x", temp.x);
        animator.SetFloat("y", temp.y);

        if (stateInfo.normalizedTime >= 0.7f   && !once)
        {
            once = true;
            switch (GetCurrentClipName(animator))
            {
                case "ataque2Arriba":
                    tempAttackPos = 0;
                    Instantiate(axe, enemigoConMovimiento.attack2Positions[0].transform.position, Quaternion.identity);
                    break;

                case "ataque2Abajo":
                    tempAttackPos = 1;
                    Instantiate(axe, enemigoConMovimiento.attack2Positions[1].transform.position, Quaternion.identity);
                    break;

                case "ataque2Derecho":
                    tempAttackPos = 2;
                    Instantiate(axe, enemigoConMovimiento.attack2Positions[1].transform.position, Quaternion.identity);

                    break;

                case "ataque2Izquierdo":
                    tempAttackPos = 3;
                    Instantiate(axe, enemigoConMovimiento.attack2Positions[3].transform.position, Quaternion.identity);
                    break;

                default:

                    break;
            }

           
        }

        if(stateInfo.normalizedTime >= 1)
        {
            CorriendoBanditBoss.isRunAttack2 = false;
            
        }
    }


    public string GetCurrentClipName(Animator animator)
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
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
