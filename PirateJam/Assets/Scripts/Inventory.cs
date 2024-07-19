using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    [SerializeField]
    private Transform carryingPosition;


    private void OnEnable()
    {
        Circle.OnCircleCollected += Add;
        Capsule.OnCapsuleCollected += Add;
    }


    public void Add(ItemData itemData, Vector2 position)
    {
        if(inventory.Count != 0)
        {
            Instantiate(inventory[0].itemData.itemObject, position, Quaternion.identity);
            Remove();
        }
        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        Debug.Log("Added = " + newItem.itemData.name);
        Debug.Log(inventory.Count);
        carryingPosition.gameObject.GetComponent<SpriteRenderer>().sprite = itemData.icon;
    }

    public void Remove()
    {
        inventory.RemoveAt(inventory.Count - 1);
        Debug.Log("Silindi");
    }


}
