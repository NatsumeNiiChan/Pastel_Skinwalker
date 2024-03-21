using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    private PickUp pickUpScript;

    private bool isLaundry;
    public int LaundryCount;
    public int TaskCount;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isLaundry == true)
        {
            TaskCount++;
            isLaundry = false;
            uiObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laundry")
        {
            collision.gameObject.GetComponent<PickUp>().IsPickable = true;
            uiObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Washingmachine" && LaundryCount >= 5)
        {
            uiObject.SetActive(true);
            isLaundry = true;
            LaundryCount = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laundry")
        {
            collision.gameObject.GetComponent<PickUp>().IsPickable = false; 
            uiObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Washingmachine")
        {
            uiObject.SetActive(false);
        }
    }
}
