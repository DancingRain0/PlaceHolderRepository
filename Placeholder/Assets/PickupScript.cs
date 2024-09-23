using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour

{
    public Transform holdSpot;
    public LayerMask pickupMask;
    public Vector3 pickupPosition { get; set; }
    private GameObject itemHolding;
    public bool hasItem = false;
    void Update()
    {
        PlayerStatus playerStatus = GetComponent<PlayerStatus>();
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + pickupPosition;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }

            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + pickupPosition, .4f, pickupMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    (playerStatus.canCollect) = true;
                }
            }
        }
    }
}
    
