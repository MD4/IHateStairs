﻿using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
  public List<GameObject> gameObjects = new List<GameObject>();
  public List<InventoryItem> itemObjects = new List<InventoryItem>();
  public InventoryDataBase DataBase;
  public GameObject slots;
  private int x = -83;
  private int y = 29;

  // Use this for initialization
  void Start()
  {
    for (var i = 0; i < 2; i++)
    {
      for (var j = 0; j < 4; j++)
      {
        GameObject gameObject = Instantiate(slots);
        gameObjects.Add(gameObject);
        gameObject.transform.SetParent(this.gameObject.transform);
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
        gameObject.name = "Slot " + i + "." + j;
        x += 55;
        if (j == 3)
        {
          x = -83;
          y -= 55;
        }
      }
    }
  }

  public void AddItem(int id)
  {
    if (itemObjects.Count < 8)
    {
      Debug.Log("itemObjects.Count = " + itemObjects.Count);
      Debug.Log("DataBase.Count = " + DataBase.Items.Count);
      Debug.Log("Looking for " + id);
      var tmp = DataBase.Items.Find(item => item.ItemId == id);
      if (tmp != null)
      {
        itemObjects.Add(tmp);
        gameObjects[itemObjects.Count - 1].GetComponent<ItemController>().Item = tmp;
      }
    }
  }

  public void Remove(InventoryItem item)
  {
    var index = itemObjects.IndexOf(item);
    gameObjects[index].GetComponent<ItemController>().Item = null;
    itemObjects.RemoveAt(index);
  }
}