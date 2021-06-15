using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrocediendoState1 : StateMachineBehaviour
{
    EnemigoBasico enemigoBasico;
    GameObject objetivo;
    public float distanciaRetroceder;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoBasico = animator.gameObject.GetComponent<EnemigoBasico>();
        objetivo = enemigoBasico.GetObjetivo();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, objetivo.transform.position) < distanciaRetroceder)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, objetivo.transform.position, -enemigoBasico.velocidad * Time.deltaTime);
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
