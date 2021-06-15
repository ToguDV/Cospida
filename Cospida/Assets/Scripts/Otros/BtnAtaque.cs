using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAtaque : MonoBehaviour
{
    GameObject player;
    private Animator animator;
    private PlayerController playerController;
    private Animator animSelf;
    void Start()
    {
        player = GameObject.Find("Player");
        animSelf = GetComponent<Animator>();
        animator = player.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        animSelf.SetBool("isAttack", animator.GetBool("isAttack"));
    }

    public void Clickxd()
    {
        if (!animator.GetBool("isDead"))
        {
            if (!animator.GetBool("isAttack") && !animator.GetBool("damage"))
            {
                playerController.attackFinal();
            }

           
        }

        
    }
}
