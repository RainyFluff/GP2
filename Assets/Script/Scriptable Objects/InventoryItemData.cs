using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ItemType
{
    Color,
    Sticker,
    Model
}
[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string name;
    public ItemType type;
    public Sprite icon;
    public Object item;
}
