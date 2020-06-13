using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 5;

    private List<IInventoryItem> mItens = new List<IInventoryItem>();

    public event EventHandler<InventoryEventsArgs> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        /*if(mItens.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled)
            {
                collider.enabled = false;

                mItens.Add(item);

                //item.OnPickup();


                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventsArgs(item));
                }
            }
        }*/

    }
}
