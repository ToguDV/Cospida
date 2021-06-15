using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionar : MonoBehaviour
{
    public Camera camera;
    public GameObject enemy;
    void Start()
    {
        float height = camera.orthographicSize - 1;
        float width = camera.orthographicSize * camera.aspect - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float height = camera.orthographicSize - 1;
        float width = camera.orthographicSize * camera.aspect;
        if (camera.transform.position.y - height > enemy.transform.position.y)
        {
            if (width - camera.transform.position.x < enemy.transform.position.x - camera.transform.position.x - 5)
            {

            }

            else if (-width - camera.transform.position.x > enemy.transform.position.x - camera.transform.position.x - 6)
            {

            }

            else
            {
                transform.position = new Vector3(enemy.transform.position.x, camera.transform.position.y - height, 0);
            }


        }

        /*
        if (camera.transform.position.y - height < enemy.transform.position.y)
        {
            transform.position = new Vector3(enemy.transform.position.x, camera.transform.position.y - height, 0);
        }
        */

    }
}
