using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField]
    private Transform carryingPosition;

    public ItemData itemHold;
    private void OnEnable()
    {
        ItemScript.OnItemCollected += Add;
    }


    public void Add(ItemData itemData, Vector2 position)
    {
        if (inventory.Count != 0)
        {
            Instantiate(inventory[0].itemData.itemObject, position, Quaternion.identity);
            Remove();
        }
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        Debug.Log("Added = " + newItem.itemData.name);
        Debug.Log(inventory.Count);
        carryingPosition.gameObject.GetComponent<SpriteRenderer>().sprite = itemData.icon;
        itemHold = itemData;
    }

    public ItemData GetItemHold()
    {
        return itemHold;
    }

    public void Remove()
    {
        inventory.RemoveAt(inventory.Count - 1);
        carryingPosition.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        Debug.Log("Silindi");
    }


}
