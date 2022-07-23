using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public float speed = 20f;
    public Transform ghost;
    public bool ghostMode = false;

    private GameObject interactable = null;
    private Vector2 movement;

    void Update()
    {
        move();
        interaction();
        ghostTransition();
    }

    void interaction()
    {
        if (interactable == null || !Input.GetButtonDown("Jump")) return; // If near an interactable object and push space
        interactController ineraction = interactable.GetComponent<interactController>();
        ineraction.interacted = !ineraction.interacted;
    }

    void ghostTransition()
    {
        if (interactable != null) { return; }

        if (Input.GetButtonDown("Jump") && ghostMode)
        {
            // Return to ghost
            float distance = Mathf.Sqrt(Mathf.Pow(ghost.position.x - transform.position.x, 2) + Mathf.Pow(ghost.position.y - transform.position.y, 2));
            if (distance < 26)
            {
                ghostMode = false;
                ghost.gameObject.SetActive(false);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            // Ghost leave body
            ghostMode = true;
            ghost.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            ghost.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    // Player Movement
    void move()
    {
        float inputX = Input.GetAxis("Horizontal"); // Read movement whe not in ghost mode
        movement = new Vector2(speed * inputX, 0);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement; // Apply movement
    }

    // This trigger is to detect when near interactable objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.transform.parent.gameObject; 
        if (interactable.name != "Switch") interactable = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
}
