using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorriendoBanditBoss : StateMachineBehaviour
{
    private EnemigoConMovimiento enemigoConMovimiento;
    public float acercamiento;
    public string[] nameAttacks;
    private int randomPickAttack2;
    public GameObject[] posRunAttack2;
    public static bool isRunAttack2;
    public float delayVerificarLlegada = 5f;
    float timeVerificarLlegada = 0f;
    bool onceCrossAttack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeVerificarLlegada = 0f;
        enemigoConMovimiento = animator.gameObject.GetComponent<EnemigoConMovimiento>();
        enemigoConMovimiento.setProtected(true);

        if (HurtBanditBoss.hits < 4 || EnemigoConMovimiento.currentFase < 2)
        {
            randomPickAttack2 = Random.Range(0, posRunAttack2.Length);
            Debug.LogWarning(randomPickAttack2);
            enemigoConMovimiento.destination.target = enemigoConMovimiento.GetObjetivo().transform;

        }

        if (HurtBanditBoss.hits >= 4 && EnemigoConMovimiento.currentFase >= 2 && !onceCrossAttack)
        {
            onceCrossAttack = true;
            foreach (Ballesta ballesta in enemigoConMovimiento.ballestas)
            {
                ballesta.ShootWithDelay();
            }
        }

        enemigoConMovimiento.aipath.canMove = true;
        posRunAttack2 = GameObject.FindGameObjectsWithTag("posRunAttack2");

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.gameObject.transform.position, enemigoConMovimiento.GetObjetivo().transform.position) <= acercamiento && !isRunAttack2)
        {
            animator.SetBool("Attack1", true);
        }

        if (HurtBanditBoss.hits >= 4 && EnemigoConMovimiento.currentFase >= 2)
        {
            enemigoConMovimiento.setProtected(true);
            EmpezarAtaque2(animator); 
        }
        enemigoConMovimiento.Movimiento();
        if (enemigoConMovimiento.combed)
        {
            enemigoConMovimiento.combed = false;
            animator.SetBool("Attack3", true);
        }
    }

    public void EmpezarAtaque2(Animator animator)
    {
        enemigoConMovimiento.collider2D.enabled = false;
        timeVerificarLlegada += Time.deltaTime;
        enemigoConMovimiento.destination.target = posRunAttack2[randomPickAttack2].transform;
        enemigoConMovimiento.aipath.maxSpeed = 13f;
        isRunAttack2 = true;
        if (timeVerificarLlegada >= delayVerificarLlegada)
        {
            verificarLlegada(animator);
        }
    }


    public void verificarLlegada(Animator animator)
    {
        if (enemigoConMovimiento.aipath.reachedDestination)
        {

            enemigoConMovimiento.aipath.maxSpeed = 6f;
            HurtBanditBoss.hits = 0;
            enemigoConMovimiento.collider2D.enabled = true;
            animator.SetBool("Attack2", true);
            onceCrossAttack = false;

        }
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigoConMovimiento.aipath.canMove = false;
        animator.SetBool("isMove", false);
    }
}
