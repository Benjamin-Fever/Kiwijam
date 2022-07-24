using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour
{
    public int speed = 20;
    public Transform player;

    private GameObject interactable = null;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        interaction();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        GameObject collideObj = collision.transform.parent.gameObject;
        if (collideObj.name == "Spotlight")
        {
            player.GetComponent<playerControls>().ghostMode = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.SetActive(false);
        }
        interactable = collision.transform.parent.gameObject;
        if (interactable.tag != "Ghost_Interact") interactable = null;
    }

    private void OnTriggerExit2D(Collider2D collision) { interactable = null; }

    void interaction()
    {
        if (interactable == null || !Input.GetButtonDown("Jump")) return;
        interactController ineraction = interactable.GetComponent<interactController>();
        ineraction.interacted = !ineraction.interacted;
    }
}
