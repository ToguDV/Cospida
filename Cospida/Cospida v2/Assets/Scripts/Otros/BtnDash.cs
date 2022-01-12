using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDash : MonoBehaviour
{
    GameObject player;
    private Animator animator;
    private PlayerController playerController;
    private Animator animSelf;
    void Start()
    {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!animator.GetBool("isDead"))
            {
                if (!animator.GetBool("isAttack") && !animator.GetBool("damage"))
                {
                    playerController.Dashear();
                }
            }
        }
    }

    public void Click()
    {
        if (!animator.GetBool("isDead"))
        {
            if (!animator.GetBool("isAttack") && !animator.GetBool("damage"))
            {
                playerController.Dashear();
            }


        }


    }
}
