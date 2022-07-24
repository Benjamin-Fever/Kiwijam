using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public int speed = 20;
    public Transform ghost;
    public bool ghostMode = false;
    public Transform groundedObj;

    private GameObject interactable = null;
    private Vector2 movement;
    private bool grounded;


    // Update is called once per frame
    void Update()
    {
        //body.AddForce(transform.up * (10 * 200 * (Input.GetButtonDown("Jump") ? 1f : 0f))); Code for jump
        move();
        interaction();
        ghostTransition();
    }

    void interaction()
    {
        if (interactable == null || !Input.GetButtonDown("Jump") || ghostMode) return;
        interactController ineraction = interactable.GetComponent<interactController>();
        ineraction.interacted = !ineraction.interacted;
    }

    void ghostTransition()
    {
        if (interactable != null && !ghostMode) { return; }

        if (Input.GetButtonDown("Jump") && ghostMode)
        {
            // Return to ghost
            float distance = Mathf.Sqrt(Mathf.Pow(ghost.position.x - transform.position.x, 2) + Mathf.Pow(ghost.position.y - transform.position.y, 2));
            Debug.Log(distance);
            if (distance <= 6)
            {
                ghostMode = false;
                ghost.gameObject.SetActive(false);
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            // Ghost leave body
            ghostMode = true;
            ghost.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            ghost.gameObject.SetActive(true);
        }
    }

    // Player Movement
    void move()
    {
        float inputX = 0;
        if (!ghostMode) inputX = Input.GetAxis("Horizontal");
        movement = new Vector2(speed * inputX, 0);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    // This trigger is to detect when near interactable objects
    private void OnTriggerEnter2D(Collider2D collision)
    {

        interactable = collision.transform.parent.gameObject;
        if (interactable.name == "Extended")
        {
            interactable = interactable.transform.parent.gameObject;
        }
        Debug.Log(interactable.name);
        if (interactable.tag != "Human_Interact") interactable = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactable = collision.transform.parent.gameObject;
        if (interactable.name == "Extended")
        {
            interactable = interactable.transform.parent.gameObject;
        }
        Debug.Log(interactable.name);
        if (interactable.tag != "Human_Interact") interactable = null;
    }

    private void OnTriggerExit2D(Collider2D collision) { interactable = null; }
}
