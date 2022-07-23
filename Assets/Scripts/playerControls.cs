using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed = 20;
    public float gravity = 10;

    private bool ghostMode = false;
    private Transform interactable = null;
    //public float jumpHeight = 10;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump")) ghostMode = !ghostMode; // Switch ghost states
        move();
        interaction();

        //body.AddForce(transform.up * (jumpHeight * 200 * (Input.GetButtonDown("Jump") ? 1f : 0f))); Code for jump

    }

    void interaction()
    {
        if (interactable == null || !Input.GetButtonDown("Jump")) return;
        Debug.Log("test");
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

        interactable = collision.transform.parent.transform;
        if (interactable.tag != "interact") interactable = null;
    }

    private void OnTriggerExit2D(Collider2D collision) { interactable = null; }
}
