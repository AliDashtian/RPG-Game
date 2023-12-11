using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public InventoryObject PlayerInventory;

    private bool haveItem;
    private GroundItem targetItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!haveItem)
        {
            haveItem = other.TryGetComponent(out targetItem);

            if (haveItem)
                print("Press Y to Pickup.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetItem != null)
        {
            haveItem = false;
            targetItem = null;
        }
    }

    private void Update()
    {
        if (haveItem)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {                
                PlayerInventory.AddItem(new Item(targetItem.Item), targetItem.Amount);
                Destroy(targetItem.gameObject);
                targetItem = null;
                haveItem = false;
            }
        }
    }
}
