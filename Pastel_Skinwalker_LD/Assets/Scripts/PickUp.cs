using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    public bool IsPickable;
    private PickUpManager pickUpMScript;

    private void Awake()
    {
        pickUpMScript = FindObjectOfType<PickUpManager>();
    }

    private void Update()
    {
        if (IsPickable == true && Input.GetKeyDown(KeyCode.Space))
        {
            uiObject.SetActive(false);
            pickUpMScript.LaundryCount++;
            Destroy(gameObject);
        }
    }
}
