using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public int levelToTeleport = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        SceneManager.LoadScene("Nivel"+levelToTeleport + PlayerPrefs.GetString("NivelWin"+levelToTeleport, "-1"));
        }
    }
}
