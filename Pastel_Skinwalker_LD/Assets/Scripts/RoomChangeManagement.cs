using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomChangeManagement : MonoBehaviour
{
    [SerializeField] private GameObject activeRoom;
    [SerializeField] private GameObject oldRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = true;
        activeRoom = collision.transform.parent.gameObject;
        //activeRoom.GetComponentInChildren<SpriteRenderer>().enabled = false;
        activeRoom.GetComponentInChildren<TilemapRenderer>().enabled = true;

        Invoke("ChangeRoom", 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collision.gameObject.GetComponentInChildren<PolygonCollider2D>().enabled = false;

        //oldRoom.GetComponentInChildren<SpriteRenderer>().enabled = true;
        oldRoom.GetComponentInChildren<TilemapRenderer>().enabled = false;
    }

    private void ChangeRoom()
    {
        oldRoom = activeRoom;
    }
}
