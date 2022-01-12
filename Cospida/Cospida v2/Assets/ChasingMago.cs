using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMago : StateMachineBehaviour
{
    private MagoController magoController;
    RaycastHit2D hit;
    public float randomRatio;
    float time;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("select", 0);
        time = 0f;
        magoController = animator.gameObject.GetComponent<MagoController>();
        if (magoController != null)
        {
            Debug.Log("mago no es nulo");
            magoController.destination.target = magoController.GetObjetivo().transform;
            magoController.aipath.canMove = true;
        }

        else
        {
            Debug.Log("Mago nulo");
        }

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if (time >= randomRatio)
        {
            time = 0;

        }
        magoController.Movimiento();

    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        magoController.aipath.canMove = false;
        animator.SetBool("isChasing", false);
    }
}
