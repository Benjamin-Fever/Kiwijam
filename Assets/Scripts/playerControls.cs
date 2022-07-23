using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public int speed = 20;
    public Transform ghost;

    public bool ghostMode = false;
    private GameObject interactable = null;

    // Update is called once per frame
    void Update()
    {
        // // Switch ghost states
        //body.AddForce(transform.up * (10 * 200 * (Input.GetButtonDown("Jump") ? 1f : 0f))); Code for jump

        move();
        interaction();
        ghostTransition();


    }

    void interaction()
    {
        if (interactable == null || !Input.GetButtonDown("Jump")) return;
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
            if (distance < 4)
            {
                ghostMode = false;
                ghost.gameObject.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = true;

            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            // Ghost leave body
            ghostMode = true;
            ghost.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            ghost.gameObject.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Player Movement
    void move()
    {
        if (ghostMode) return;

        float moveX = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(moveX, 0).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    // This trigger is to detect when near interactable objects
    private void OnTriggerEnter2D(Collider2D collision)
    {

        interactable = collision.transform.parent.gameObject;
        if (interactable.tag != "interact") interactable = null;
    }

    private void OnTriggerExit2D(Collider2D collision) { interactable = null; }
}
