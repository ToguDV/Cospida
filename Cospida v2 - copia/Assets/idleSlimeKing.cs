using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor;

public class idleSlimeKing : StateMachineBehaviour
{

    public int maxHits;
    SlimeKingController slimeKingController;
    GameObject slimeKing;
    int last;
    public float ratio;
    float time;
    int countCarga;
    int countInvocar;
    int countDisparar;
    bool firstFase3;
    bool first = true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (first)
        {
            firstFase3 = true;
            first = false;
        }
        //Reseteo de valores
        
        slimeKing = GameObject.Find("Slimeking");
        animator.gameObject.GetComponent<SlimeKingController>().setProtected(false);
        animator.gameObject.GetComponentInParent<AIPath>().canMove = true;
        animator.SetBool("isDamageAturdido", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if (time >= ratio)
        {
            cambioEstado(animator);
        }
        if (SlimeKingController.hits >= maxHits)
        {
            cambioEstado(animator);
        }
    }

    public void cambioEstado(Animator animator)
    {
        SlimeKingController.hits = 0;

        int random = Random.Range(1, FaseController.bossFase + 2);


        if (firstFase3 && FaseController.bossFase == 2)
        {
            random = 3;
            firstFase3 = false;
        }

        time = 0;


        switch (random)
        {


            case 1:
                countInvocar++;
                animator.gameObject.GetComponentInParent<AIPath>().canMove = false;
                animator.gameObject.GetComponent<SlimeKingController>().setProtected(true);
                animator.SetBool("isInvoke", true);
                break;

            case 2:

                animator.gameObject.GetComponentInParent<AIPath>().canMove = false;
                animator.gameObject.GetComponent<SlimeKingController>().setProtected(true);
                animator.SetBool("isPreparingC", true);
                animator.gameObject.GetComponent<SlimeKingController>().escudo.SetActive(false);
                last = 2;


                break;

            case 3:

                animator.gameObject.GetComponentInParent<AIPath>().canMove = true;
                animator.gameObject.GetComponent<SlimeKingController>().setProtected(true);
                animator.SetBool("isDisparando", true);
                last = 2;


                break;
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
