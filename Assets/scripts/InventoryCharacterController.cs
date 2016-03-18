using UnityEngine;
using System.Collections;

public class InventoryCharacterController : MonoBehaviour
{
  public Inventory Inventory;
  private static bool filled = false;
  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (!filled)
    {
      Inventory.AddItem(0);
      Inventory.AddItem(1);
      Inventory.AddItem(1);
      Inventory.AddItem(0);
      Inventory.AddItem(1);
      Inventory.AddItem(1);
      filled = true;
    }
  }
}