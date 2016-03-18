using UnityEngine;
using System.Collections.Generic;

public class InventoryDataBase: MonoBehaviour
{
  public List<InventoryItem> Items;

  void Start()
  {
    Items = new List<InventoryItem>();
    Items.Add(new InventoryItem(0, "coin", "Collect me", InventoryItem.ItemType.Other));
    Items.Add(new InventoryItem(1, "potion-item", "Restaure your health", InventoryItem.ItemType.Consumable));
  }
}