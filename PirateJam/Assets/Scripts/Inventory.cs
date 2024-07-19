using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();



    private void OnEnable()
    {
        Circle.OnCircleCollected += Add;
    }


    public void Add(ItemData itemData, Vector2 position)
    {
        
        if (inventory.Count > 0)
        {
            Debug.Log("Ekleniyor");
            Instantiate(itemData.itemObject, position, Quaternion.identity);
            Remove();
        }
       
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        Debug.Log("Added = " + newItem.itemData.name);
    }

    public void Remove()
    {
        inventory.RemoveAt(inventory.Count -1);
    }


}
