using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaksDown : StateMachineBehaviour
{
    PeaksController peaksController;
    public float delayTime;
    float time;
    private PlayerController player;
    public float damage;
    private bool once;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        once = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        time = 0f;
        peaksController = animator.gameObject.GetComponent<PeaksController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!peaksController.manual)
        {
            time += Time.deltaTime;
            if(stateInfo.normalizedTime >= 1)
            {
                if (!once && peaksController.isPlayer)
                {
                    player.Herirse(damage, 0f, Vector2.zero, 0f);
                    once = true;
                }
                
                if(time >= delayTime)
                {
                    animator.SetBool("isActive", false);
                }
            }
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
