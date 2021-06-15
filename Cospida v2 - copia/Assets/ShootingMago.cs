using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMago : StateMachineBehaviour
{
    public float shootDelayInitial;
    float time;
    bool firstShoot;
    public GameObject[] flechas;
    MagoController mago;
    AnimatorClipInfo[] clipInfo;
    float shootRatio;
    Vector3 temp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("select", 2);
        mago = animator.gameObject.GetComponent<MagoController>();
        firstShoot = true;
        time = 0;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        shootRatio = clipInfo[0].clip.averageDuration;
        temp = new Vector3(mago.GetObjetivo().transform.position.x - animator.transform.position.x, mago.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
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

                case "shootingAbajo":

                    Instantiate(flechas[0], mago.attackPositions[0].transform.position, mago.attackPositions[0].transform.rotation);
                    break;
                case "shootingArriba":
                    Instantiate(flechas[1], mago.attackPositions[1].transform.position, mago.attackPositions[1].transform.rotation);

                    break;
                case "shootingIzquierda":
                    Instantiate(flechas[2], mago.attackPositions[2].transform.position, mago.attackPositions[2].transform.rotation);

                    break;
                case "shootingDerecha":
                    Instantiate(flechas[3], mago.attackPositions[3].transform.position, mago.attackPositions[3].transform.rotation);

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
//
}