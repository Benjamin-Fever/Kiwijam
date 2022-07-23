using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour
{
    public int speed = 20;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 

        GameObject collideObj = collision.transform.parent.gameObject;
        if (collideObj.name == "Spotlight")
        {
            player.GetComponent<playerControls>().ghostMode = false;
            player.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
