using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FixPixelPerfect : MonoBehaviour
{
    PixelPerfectCamera pixelPerfectCamera;
    void Awake()
    {
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        if(Screen.width / Screen.height == 16/9)
        {
            pixelPerfectCamera.refResolutionX = 320;
            pixelPerfectCamera.refResolutionY = 180;
            
        }

        else if (Screen.width / Screen.height == 4 / 3)
        {
            pixelPerfectCamera.refResolutionX = 80;
            pixelPerfectCamera.refResolutionY = 60;
        }

        else if (Screen.width / Screen.height == 5 / 4)
        {
            pixelPerfectCamera.refResolutionX = 100;
            pixelPerfectCamera.refResolutionY = 80;
        }

        else if (Screen.width / Screen.height == 8 / 5)
        {
            pixelPerfectCamera.refResolutionX = 320;
            pixelPerfectCamera.refResolutionY = 200;
        }

        else if (Screen.width / Screen.height == 21 / 9)
        {
            pixelPerfectCamera.refResolutionX = 420;
            pixelPerfectCamera.refResolutionY = 180;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
