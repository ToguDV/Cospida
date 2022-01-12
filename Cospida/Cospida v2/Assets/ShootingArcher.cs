using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArcher : StateMachineBehaviour
{
    public float shootDelayInitial;
    float time;
    bool firstShoot;
    public GameObject[] flechas;
    ArcherController archer;
    AnimatorClipInfo[] clipInfo;
    float shootRatio;
    Vector3 temp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        archer = animator.gameObject.GetComponent<ArcherController>();
        firstShoot = true;
        time = 0;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        
        shootRatio = clipInfo[0].clip.averageDuration;
        temp = new Vector3(archer.GetObjetivo().transform.position.x - animator.transform.position.x, archer.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp.x = Mathf.Round(temp.x);
        temp.y = Mathf.Round(temp.y);
        animator.SetFloat("x", temp.x);
        animator.SetFloat("y", temp.y);

        if (time >= shootRatio)
        {
            temp.x = Mathf.Round(temp.x);
            temp.y = Mathf.Round(temp.y);
            animator.SetFloat("x", temp.x);
            animator.SetFloat("y", temp.y);

            time = 0;
            switch (clipInfo[0].clip.name)
            {

                case "AttackTras":
                    
                    Instantiate(flechas[0], archer.attackPositions[0].transform.position, Quaternion.identity);
                    break;
                case "Attack front":
                    Instantiate(flechas[1], archer.attackPositions[1].transform.position, Quaternion.identity);

                    break;
                case "AttackIz":
                    Instantiate(flechas[2], archer.attackPositions[2].transform.position, Quaternion.identity);

                    break;
                case "AttackDer":
                    Instantiate(flechas[3], archer.attackPositions[3].transform.position, Quaternion.identity);

                    break;
                
               
                default:
                    Debug.LogError("La instanciacion de la flechita se bugueo y su valor es:" + clipInfo[0].clip.name);
                    break;
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
