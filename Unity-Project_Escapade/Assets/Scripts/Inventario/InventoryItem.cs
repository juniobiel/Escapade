using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem {

    string Name { get; }

    //public aqui é meu
    Sprite Image { get; }

    void OnPickup();
}

public class InventoryEventsArgs : EventArgs
{
    public InventoryEventsArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}
