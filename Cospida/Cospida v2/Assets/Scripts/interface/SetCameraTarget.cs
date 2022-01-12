using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetCameraTarget : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerGameObject;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        playerGameObject = GameObject.Find("Player");
        cinemachineVirtualCamera.Follow = playerGameObject.GetComponent<Transform>();
    }
}
