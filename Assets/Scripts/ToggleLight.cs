using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private bool lightIsOn;
    
    void Start()
    {
        TurnOnLight();
    }


    private void ToggleLightSwitch()
    {
        if (lightIsOn)
        {
            TurnOffLight();
        }
        else
        {
            TurnOnLight();
        }
    }

    private void TurnOnLight()
    {
        gameObject.SetActive(true);
    }

    private void TurnOffLight()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
