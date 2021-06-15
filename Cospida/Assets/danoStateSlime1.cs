using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoStateSlime1 : StateMachineBehaviour
{
    private SlimeController slime;
    public Spawner spawner;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        slime = animator.gameObject.GetComponent<SlimeController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.gameObject.GetComponent<EnemigoBasico>().vida <= 0)
        {
            slime.tag = "Untagged";
            animator.SetBool("isDead", true);
            
        }
        if (stateInfo.normalizedTime >= 1)
        {
            slime.CancelInvoke();
            slime.InvokeRepeating("ActivarMovimiento", slime.frecuencia, slime.frecuencia);
            slime.InvokeRepeating("DesactivarMovimiento", slime.frecuencia + slime.duracion, slime.frecuencia);
            slime.InvokeRepeating("activarAlerta", slime.frecuencia/ 1.5f, slime.frecuencia);
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
