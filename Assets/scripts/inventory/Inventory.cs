using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
  public List<GameObject> gameObjects = new List<GameObject>();
  public static List<InventoryItem> itemObjects = new List<InventoryItem>();
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
        if (itemObjects.Count < 8)
        {
          Debug.Log("New basic item");
          itemObjects.Add(new InventoryItem());
        }
        else
        {
          Debug.Log("restoring [" + (i*4 + j) + "]" + itemObjects[i*4 + j].ItemId);
          gameObject.GetComponent<ItemController>().Item = itemObjects[i*4 + j];
        }
        x += 55;
        if (j == 3)
        {
          x = -83;
          y -= 55;
        }
      }
    }
  }

  private int getFreeSlotsCount()
  {
    var freeSlotsCount = itemObjects.FindAll(item => item.ItemId == -1).Count;
    return freeSlotsCount;
  }

  private int getFirstFreeSlotIndex()
  {
    int firstFreeSlotIndex = itemObjects.IndexOf(new InventoryItem());
    return firstFreeSlotIndex;
  }

  public void AddItem(int id)
  {
    if (getFreeSlotsCount() > 0)
    {
      int index = getFirstFreeSlotIndex();
      itemObjects.RemoveAt(index);
      var inventoryItem = DataBase.Items.Find(item => item.ItemId == id);
      itemObjects.Insert(index, inventoryItem);
      gameObjects[index].GetComponent<ItemController>().Item = inventoryItem;
    }
  }

  public void Remove(string item)
  {
    item = item.Substring(5);

    int index = flatten(item);

    gameObjects[index].GetComponent<ItemController>().Item = null;
    itemObjects.RemoveAt(index);
    itemObjects.Insert(index, new InventoryItem());
  }

  private int flatten(string indexs)
  {
    int i = indexs[0] - '0';
    int j = indexs[2] - '0';
    return i*4 + j;
  }
}