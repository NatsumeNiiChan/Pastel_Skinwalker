using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D playerCollider;
    private float vertical;
    private float horizontal;

    [SerializeField] private GameObject activeRoom;
    [SerializeField] private GameObject oldRoom;

    [SerializeField] private int movementSpeed = 5;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = new Vector2(vertical * movementSpeed, horizontal * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activeRoom = collision.transform.parent.gameObject;
        activeRoom.GetComponentInChildren<SpriteRenderer>().enabled = false;

        Invoke("ChangeRoom", 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        oldRoom.GetComponentInChildren<SpriteRenderer>().enabled = true;
    }

    private void ChangeRoom()
    {
        oldRoom = activeRoom;
    }
}
