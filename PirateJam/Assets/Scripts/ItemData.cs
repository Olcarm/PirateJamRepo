using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public GameObject itemObject;
}
