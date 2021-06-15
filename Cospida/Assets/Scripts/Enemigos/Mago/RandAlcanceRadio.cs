using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandAlcanceRadio : MonoBehaviour
{
    public CircleCollider2D circle;
    public float minRadio = 3f, maxRadio = 5f;
    float radio;
    // Start is called before the first frame update
    void Start()
    {
        radio = Random.Range(minRadio, maxRadio);
        circle.radius = radio;
    }
}
