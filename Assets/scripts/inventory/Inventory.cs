using System;
using UnityEngine;
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
        itemObjects.Add(new InventoryItem());
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

  private int getFreeSlotsCount()
  {
    var freeSlotsCount = itemObjects.FindAll(item => item.ItemId == -1).Count;
    Debug.Log("free slots: " + freeSlotsCount);
    return freeSlotsCount;
  }

  private int getFirstFreeSlotIndex()
  {
    int firstFreeSlotIndex = itemObjects.IndexOf(new InventoryItem());
    Debug.Log("firstFreeSlotIndex = " + firstFreeSlotIndex);
    return firstFreeSlotIndex;
  }

  public void AddItem(int id)
  {
    if (getFreeSlotsCount() > 0)
    {
      int index = getFirstFreeSlotIndex();
      itemObjects.RemoveAt(index);
      var inventoryItem = DataBase.Items.Find(item => item.ItemId == id);
      Debug.Log("Inserting " + inventoryItem.ItemId + " at " + index);
      itemObjects.Insert(index, inventoryItem);
      gameObjects[index].GetComponent<ItemController>().Item = inventoryItem;
    }
  }

  public void Remove(string item)
  {
    item = item.Substring(5);

    int index = flatten(item);

    Debug.Log("Removing " + item + " at index " + index);
    gameObjects[index].GetComponent<ItemController>().Item = null;
    itemObjects.RemoveAt(index);
  }

  private int flatten(string indexs)
  {
    int i = indexs[0] - '0';
    int j = indexs[2] - '0';
    return i*4 + j;
  }
}