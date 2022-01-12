using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class damageSlimeKing : StateMachineBehaviour
{
    public float duration;
    float time = 0;
    public AudioClip[] sonidos;
    AudioSource audioSource;
    int indexSound = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = GameObject.Find("Slime king").GetComponent<AudioSource>();
        audioSource.clip = sonidos[indexSound];
        SlimeKingController.hits++;
        audioSource.Play();
        time = 0;
        indexSound++;
        if (indexSound + 1 < sonidos.Length)
        {
            indexSound++;
        }

        else
        {
            indexSound = 0;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;


        if (time >= duration)
        {
            if (animator.gameObject.GetComponent<SlimeKingController>().vida <= 0)
            {
                animator.SetBool("isDeath", true);
            }

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
