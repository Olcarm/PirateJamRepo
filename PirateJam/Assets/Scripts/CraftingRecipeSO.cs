using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CraftingRecipes")]
public class CraftingRecipeSO : ScriptableObject
{
    public ItemData output;

    public ItemData item1;

    public ItemData item2;

    public ItemData item3;
}
