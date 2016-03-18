using UnityEngine;
using System.Collections.Generic;

public class InventoryDataBase : MonoBehaviour
{
  public List<InventoryItem> Items = new List<InventoryItem>();

  void Start()
  {
    Items.Add(new InventoryItem(0, "coin", "It's a coin", InventoryItem.ItemType.Other));
  }
}