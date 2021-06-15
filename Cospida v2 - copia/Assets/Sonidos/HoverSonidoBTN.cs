using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSonidoBTN : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource myFx;
    public AudioClip hoverFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
}
