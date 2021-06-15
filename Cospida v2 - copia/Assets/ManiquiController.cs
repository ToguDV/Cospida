using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManiquiController : MonoBehaviour
{
    OndaExpansiva ondaExpansiva;
    private BoxCollider2D boxCollider2D;
    private PlayerController playerController;
    private int lugarAtaque;
    public Animator animator;
    private int numero;
    public float TiempoDeVidaTextoDaño;
    private float tiempoDaño;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        playerController = GetComponent<PlayerController>();
        text.SetActive(false);
        tiempoDaño = TiempoDeVidaTextoDaño;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDaño -= Time.deltaTime;
        if (tiempoDaño <= 0)
        {
            text.SetActive(false);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque"))
        {
            numero = Random.Range(1, 3);
            ondaExpansiva = collision.gameObject.GetComponent<OndaExpansiva>();
            Destroy(collision.gameObject);
            lugarAtaque = PlayerController.posOnda;
            if (lugarAtaque == 1 && numero==1)
            {
                animator.SetTrigger("Atacado1");
                animator.SetFloat("x", 0);
                animator.SetFloat("y", 1);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 2 && numero == 1)
            {
                animator.SetTrigger("Atacado1");
                animator.SetFloat("x", 0);
                animator.SetFloat("y", -1);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 3 && numero == 1)
            {
                animator.SetTrigger("Atacado1");
                animator.SetFloat("x", 1);
                animator.SetFloat("y", 0);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 4 && numero == 1)
            {
                animator.SetTrigger("Atacado1");
                animator.SetFloat("x", -1);
                animator.SetFloat("y", 0);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 1 && numero == 2)
            {
                animator.SetTrigger("Atacado2");
                animator.SetFloat("x", 0);
                animator.SetFloat("y", 1);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 2 && numero == 2)
            {
                animator.SetTrigger("Atacado2");
                animator.SetFloat("x", 0);
                animator.SetFloat("y", -1);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 3 && numero == 2)
            {
                animator.SetTrigger("Atacado2");
                animator.SetFloat("x", 1);
                animator.SetFloat("y", 0);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }
            else if (lugarAtaque == 4 && numero == 2)
            {
                animator.SetTrigger("Atacado2");
                animator.SetFloat("x", -1);
                animator.SetFloat("y", 0);
                text.SetActive(true);
                tiempoDaño = TiempoDeVidaTextoDaño;
            }

            print(lugarAtaque);
        }
    }
}
