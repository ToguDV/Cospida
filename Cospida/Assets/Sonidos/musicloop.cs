using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicloop : MonoBehaviour
{
	public AudioSource musicSource;
	public AudioClip musicStart;
    void Start()
    {
        musicSource.clip = musicStart;
		musicSource.Play();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
