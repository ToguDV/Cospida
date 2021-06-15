using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerteStateMago : StateMachineBehaviour
{
    public bool isSpawned = true;
    public bool isLast = false;
    GameObject win;
    public float delayDesaparecer = 3f;
    float time;
    TaskController taskController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        taskController = GameObject.Find("ListObjetivos").GetComponent<TaskController>();
        time = 0;
        animator.gameObject.tag = "Untagged";
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        time += Time.deltaTime;
        animator.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (time >= delayDesaparecer)
        {
            if (isSpawned)
            {
                Spawner.nKillsFase++;
            }
            Spawner.nKillsTotal++;
            //taskController.updateAnyCountForID(TaskController.IdArcher0);
            animator.GetComponent<MagoController>().DeletePadre();


        }
    }
}
