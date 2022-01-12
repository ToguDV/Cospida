using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDropperAttack : StateMachineBehaviour
{
    public GameObject arrow;
    private ArrowDropper arrowDropper;
    bool onceShoot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onceShoot = false;
        arrowDropper = animator.gameObject.GetComponent<ArrowDropper>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.normalizedTime >= 0.8f && !onceShoot) 
        {
            Instantiate(arrow, arrowDropper.posArrow.transform.position, Quaternion.identity);
            onceShoot = true;
        }

        if (stateInfo.normalizedTime >= 1f)
        {
            animator.SetBool("isAttack", false);
        }
    }
}
