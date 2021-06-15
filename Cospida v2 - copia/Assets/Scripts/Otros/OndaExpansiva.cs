using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaExpansiva : MonoBehaviour
{
    public float velocidad = 5f;
    public int pos;
    public Vector2 empuje;
    void Start()
    {
        empuje = Player.empuje;
        pos = PlayerController.posOnda;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime, 0f, 0f);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("proyectilMalo"))
        {
            Destroy(collision.gameObject);
        }
    }






}
