using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudandoseBandido : StateMachineBehaviour
{
    public GameObject sparks;
    float time = 0;
    public float duracion = 3;
    AnimatorClipInfo[] clipInfo;
    private EnemigoConMovimiento enemigoConMovimiento;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        Vector3 temp2;
        temp2 = new Vector3(enemigoConMovimiento.GetObjetivo().transform.position.x - animator.transform.position.x, enemigoConMovimiento.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp2.x = Mathf.Round(temp2.x);
        temp2.y = Mathf.Round(temp2.y);
        animator.SetFloat("x", temp2.x);
        animator.SetFloat("y", temp2.y);
        clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        time = 0;
        GameObject temp;
        switch (GetCurrentClipName(animator))
        {
            case "missArriba":
                temp = Instantiate(sparks, new Vector3(-0.03f, 0.53f), animator.gameObject.transform.rotation);
                temp.transform.SetParent(animator.gameObject.transform, false);
                break;

            case "missAbajo":
                temp = Instantiate(sparks, new Vector3(-0.03f, -0.34f), animator.gameObject.transform.rotation);
                temp.transform.SetParent(animator.gameObject.transform, false);
                break;

            case "missDerecha":
                
                temp = Instantiate(sparks, new Vector3(0.98f, -0.4f), animator.gameObject.transform.rotation);
                temp.transform.SetParent(animator.gameObject.transform, false);
                break;

            case "missIzquierda":
                temp = Instantiate(sparks, new Vector3(-0.91f, -0.4f), animator.gameObject.transform.rotation);
                temp.transform.SetParent(animator.gameObject.transform, false);
                break;

            default:
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        time += Time.deltaTime;
        if (time >= duracion)
        {
            animator.SetBool("isMiss", false);
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
