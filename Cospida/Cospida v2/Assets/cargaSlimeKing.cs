using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class cargaSlimeKing : StateMachineBehaviour
{
    public float time;
    float timeCount;
    GameObject slimeKing;
    bool firstUpdate = true;
    SlimeKingController slimeKingController;
    GameObject objetivo;
    public GameObject invisible;
    bool switch_ = true;
    Transform tempObjetivo;
    RaycastHit2D hit;
    Vector2 playerPos;
    Sacudida sacudida;
    public float velocidad;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(FaseController.bossFase == 1)
        {
            velocidad = 20;
        }

        else
        {
            velocidad = 30;
        }

        sacudida = GameObject.Find("Sacudida").GetComponent<Sacudida>();
        timeCount = 0;
        switch_ = true;
        firstUpdate = true;
        slimeKing = GameObject.Find("Slimeking");

        slimeKingController = slimeKing.GetComponentInChildren<SlimeKingController>();
        slimeKing.GetComponentInParent<AIPath>().canMove = false;

        if (slimeKing == null)
        {
            Debug.LogError("El slimeKing no se pudo cargar correctamente, F");
        }

        if (slimeKingController == null)
        {
            Debug.LogError("El slimeKingController no se pudo cargar correctamente, F");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // timeCount += Time.deltaTime;
        // if (timeCount >= time)
        // {
        if (firstUpdate)
        {

            objetivo = slimeKingController.GetObjetivo();
        playerPos = new Vector2(objetivo.transform.position.x - slimeKing.transform.position.x, objetivo.transform.position.y - slimeKing.transform.position.y);
        hit = Physics2D.Raycast(slimeKing.transform.position, playerPos, Mathf.Infinity, LayerMask.GetMask("Obstacle"));
            firstUpdate = false;

          }
        if(Vector2.Distance(hit.point, slimeKing.transform.position) >= 0.1f)
        {
          slimeKing.transform.position += (new Vector3(hit.point.x, hit.point.y) - slimeKing.transform.position).normalized * velocidad * Time.deltaTime;
        }

        else
        {
            animator.SetBool("isAturdido", true);
            sacudida.sacudirCamera(5, 1f);
        }
            
        
        //slimeKing.transform.position = Vector2.MoveTowards(slimeKing.transform.position, hit.point, 20 * Time.deltaTime);
    }


    // }






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
