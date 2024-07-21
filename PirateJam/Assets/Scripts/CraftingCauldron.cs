using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingCauldron : MonoBehaviour
{

    public List<ItemData> itemsThrown;
    [SerializeField] private List<CraftingRecipeSO> recipesList;

    [SerializeField] private Inventory inventory;
    private int itemsMatching = 0;

    private void Update()
    {
        if(itemsThrown.Count >= 2)
        {
            Debug.Log("Recipe complete");
            CheckForRecipe();
        }  
    }
    public void AddToRecipe(ItemData thrownItemData)
    {
        Debug.Log("Eklendi");
        itemsThrown.Add(thrownItemData);
        for (int i = 0; i < itemsThrown.Count; i++)
        {
            Debug.Log("Recipe items: " + itemsThrown[i]);
        }
    }

    private void CheckForRecipe()
    {
        foreach (CraftingRecipeSO recipe in recipesList)
        {
            itemsMatching = 0;
            for (int i = 0; i < 2; i++)
            {
                if (itemsThrown[i] == recipe.item1 || itemsThrown[i] == recipe.item2)
                {
                    itemsMatching++;
                }
            }
            if (itemsMatching == 2)
            {
                Debug.Log("Crafted item: " + recipe.output.name);
            }
        }
    }
}
