using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InventorySystem : MonoBehaviour
{
   private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
   public List<InventoryItemData> inventory;
   public static InventorySystem instance;
   public event Action newItem;

   private void Awake()
   {
      inventory = new List<InventoryItemData>();
      itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(instance);
   }

   public void Add(InventoryItemData refData)
   {
      /*
      InventoryItem newItem = new InventoryItem(refData);
      inventory.Add(newItem);
      */
      inventory.Add(refData);
      newItem?.Invoke();
   }
}

[Serializable]
public class InventoryItem
{
   public InventoryItemData data { get; private set; }

   public InventoryItem(InventoryItemData source)
   {
      data = source;
   }
}
