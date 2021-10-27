using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPeaksOnCollide : MonoBehaviour
{
    public PeaksController[] peaks; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (PeaksController peak in peaks)
            {
                peak.ManualActivation();
                peak.TriggerSetter(false);
            }
        }
    }
}
