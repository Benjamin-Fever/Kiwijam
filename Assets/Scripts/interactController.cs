using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactController : MonoBehaviour
{
    public bool interacted = false; // false if light is on, true if light is off
    public GameObject connection;
    public Transform player;
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
                float topDis = Mathf.Sqrt((Mathf.Pow(player.position.x - ladderTop.x, 2) + Mathf.Pow(player.position.y - ladderTop.y, 2)));
                float botDis = Mathf.Sqrt((Mathf.Pow(player.position.x - ladderBottom.x, 2) + Mathf.Pow(player.position.y - ladderBottom.y, 2)));

                if (topDis < botDis) { player.position = ladderBottom; }
                else                 { player.position = ladderTop; }
                interacted = false;
            }
            
        }

    }
}
