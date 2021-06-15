using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invocandoSlimeKing : StateMachineBehaviour
{
    public GameObject[] hijos1;
    public GameObject[] hijos2;
    public GameObject[] hijos3;
    int invokeCantidad = 1;
    int hijosIndex;
    int countInvocados;
    public float ratio = 3f;
    float timeCount = 0f;
    public AudioClip sonido;
    AudioSource audioSource;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = GameObject.Find("Slime king").GetComponent<AudioSource>();
        audioSource.clip = sonido;
        countInvocados = 0;
        timeCount = 0f;
        //Cantidad de invocaciones según la fase    
        switch (FaseController.bossFase)
        {

            case 0:
                invokeCantidad = Random.Range(1, 3);
                break;

            case 1:
                invokeCantidad = 1;
                break;
            case 2:
                invokeCantidad = 1;
                break;

            


        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCount += Time.deltaTime;
        if(timeCount >= ratio)
        {
            audioSource.Play();
            if (FaseController.bossFase == 0)
            {
                hijosIndex = Random.Range(0, hijos1.Length);
                Instantiate(hijos1[hijosIndex], GameObject.Find("posKing"+Random.Range(0,4)).transform.position, GameObject.Find("posKing"+Random.Range(0,4)).transform.rotation);
            }

            if (FaseController.bossFase == 1)
            {
                hijosIndex = Random.Range(0, hijos2.Length);
                Instantiate(hijos2[hijosIndex], GameObject.Find("posKing"+Random.Range(0,4)).transform.position, GameObject.Find("posKing"+Random.Range(0,4)).transform.rotation);
            }

            if (FaseController.bossFase == 2)
            {
                hijosIndex = Random.Range(0, hijos3.Length);
                Instantiate(hijos3[hijosIndex], GameObject.Find("posKing"+Random.Range(0,4)).transform.position, GameObject.Find("posKing"+Random.Range(0,4)).transform.rotation);
            }
            timeCount = 0;
            countInvocados++;
        }

        if(countInvocados >= invokeCantidad)
        {
            animator.SetBool("isInvoke", false);
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
