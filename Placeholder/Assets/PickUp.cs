using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public int scoreValue = 50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IInventory inventory = other.GetComponent<IInventory>();

            if (inventory != null)
            {
                inventory.score = inventory.score + scoreValue;
                print("Player has " + inventory.score + "G worth of items!");
                gameObject.SetActive(false);
            }
        }
    }
}
