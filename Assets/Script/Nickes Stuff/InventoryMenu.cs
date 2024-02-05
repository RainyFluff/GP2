using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private GameObject ivMenuHolder;
    public void Start()
    {
        InventorySystem.instance.newItem += UpdateMenu;
    }

    public void UpdateMenu()
    {
        for (int i = 0; i < ivMenuHolder.transform.childCount; i++)
        {
            Destroy(ivMenuHolder.transform.GetChild(i).GameObject());
        }
        foreach (InventoryItemData item in InventorySystem.instance.inventory)
        {
            AddInventorySlot(item);
        }
    }

    void AddInventorySlot(InventoryItemData item)
    {
        //create the menu icon
        GameObject icon = Instantiate((GameObject)Resources.Load("Item"), ivMenuHolder.transform);
        var im = icon.transform.GetChild(1);
        Image image = im.GetComponent<Image>();
        image.sprite = item.icon;
    }
}
