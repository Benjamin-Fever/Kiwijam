using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactController : MonoBehaviour
{
    public bool interacted = false; // false if light is on, true if light is off
    public GameObject connection;
    public Vector3 ladderTop;
    public Vector3 ladderBottom;

    // Update is called once per frame
    void Update()
    {
        if (transform.name == "Switch") 
        {
            connection.SetActive(!interacted);
            connection.transform.parent.GetChild(2).gameObject.SetActive(!interacted);
        }
        else if (transform.name == "Ladder")
        {
            if (interacted && transform.tag == "Ghost_Interact")
            {
                connection.SetActive(true);
                transform.tag = "Human_Interact";
                interacted = false;
            }
            else if (interacted && transform.tag == "Human_Interact")
            {
                // Go up ladder code
                Debug.Log("Climb ladder");
                interacted = false;
            }
            
        }

    }
}
