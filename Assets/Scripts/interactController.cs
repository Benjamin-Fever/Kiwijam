using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactController : MonoBehaviour
{
    public bool interacted = false; // false if light is on, true if light is off
    public GameObject connection; 

    // Update is called once per frame
    void Update()
    {
        if (transform.name == "Switch") 
        {
            connection.SetActive(!interacted);
            connection.transform.parent.GetChild(2).gameObject.SetActive(!interacted);
        }

    }
}
