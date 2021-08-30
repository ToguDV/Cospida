using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1Bandido : StateMachineBehaviour
{


    private EnemigoConMovimiento enemigoConMovimiento;
    AnimatorClipInfo[] clipInfo;
    float time;
    public float delayFinish;
    int tempAttackPos;
    Vector3 temp;
    public GameObject efectoAtaque;
    bool once;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        once = true;
        delayFinish = 2f;
        tempAttackPos = 0;
        time = 0;
        clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.setProtected(false);
        Debug.Log("Ataque 1 inicializado");
        delayFinish += 0.4f;
        temp = new Vector3(enemigoConMovimiento.GetObjetivo().transform.position.x - animator.transform.position.x, enemigoConMovimiento.GetObjetivo().transform.position.y - animator.transform.position.y).normalized;
        temp.x = Mathf.Round(temp.x);
        temp.y = Mathf.Round(temp.y);
        animator.SetFloat("x", temp.x);
        animator.SetFloat("y", temp.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        GameObject temp;
        if (stateInfo.normalizedTime >= 0.7f && once)
        {
            Debug.Log(GetCurrentClipName(animator));
            once = false;
            switch (GetCurrentClipName(animator))
            {
                case "Ataque1Arriba":
                    tempAttackPos = 0;
                    enemigoConMovimiento.attack1Positions[0].SetActive(true);
                    temp = Instantiate(efectoAtaque, new Vector3(-0.03f, 0.53f), Quaternion.Euler(-90f, 0f, 0f));
                    temp.transform.SetParent(animator.gameObject.transform, false);
                    break;

                case "ataque1Abajo":
                    tempAttackPos = 1;
                    enemigoConMovimiento.attack1Positions[1].SetActive(true);
                    temp = Instantiate(efectoAtaque, new Vector3(-0.03f, -0.34f), Quaternion.Euler(90f, 0f, 0f));
                    temp.transform.SetParent(animator.gameObject.transform, false);
                    break;

                case "ataque1Derecho":
                    tempAttackPos = 2;
                    enemigoConMovimiento.attack1Positions[2].SetActive(true);
                    temp = Instantiate(efectoAtaque, new Vector3(0.98f, -0.4f), Quaternion.Euler(180f, -90f, 0f));
                    temp.transform.SetParent(animator.gameObject.transform, false);

                    break;

                case "ataque1Izquierdo":
                    tempAttackPos = 3;
                    enemigoConMovimiento.attack1Positions[3].SetActive(true);
                    temp = Instantiate(efectoAtaque, new Vector3(-0.91f, -0.4f), Quaternion.Euler(180f, 90f, 0f));
                    temp.transform.SetParent(animator.gameObject.transform, false);
                    break;

                default:
                    break;
            }

            

        }


        if(stateInfo.normalizedTime >= 1)
        {
            enemigoConMovimiento.attack1Positions[tempAttackPos].SetActive(false);
        }

        if(time >= delayFinish)
        {
            animator.SetBool("Attack1", false);
            
        }

        if (enemigoConMovimiento.combed)
        {
            enemigoConMovimiento.combed = false;
            animator.SetBool("Attack3", true);
            animator.SetBool("Attack1", false);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento.attack1Positions[tempAttackPos].SetActive(false);
        enemigoConMovimiento.setProtected(true);
        animator.SetBool("Attack1", false);
    }

    public string GetCurrentClipName(Animator animator)
    {
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
    }

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
