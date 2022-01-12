using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerteStateSlimeDoble : StateMachineBehaviour
{
    public GameObject fragment;
    public bool isSpawned = true;
    public AudioClip clipDeath;
    SlimeController slime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.tag = "Untagged";
        slime = animator.gameObject.GetComponent<SlimeController>();
        slime.audioSource.clip = clipDeath;
        slime.audioSource.Play();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Collider2D>().enabled = false;
        if (stateInfo.normalizedTime >= 1)
        {
            Instantiate(fragment, animator.gameObject.transform.position, animator.gameObject.transform.rotation);
            Instantiate(fragment, animator.gameObject.transform.position, animator.gameObject.transform.rotation);
            if (isSpawned)
            {
                Spawner.nEnemys += 2;
                Spawner.nKillsFase++;
            }
            
            
            Spawner.nKillsTotal++;
            Destroy(animator.gameObject);
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
