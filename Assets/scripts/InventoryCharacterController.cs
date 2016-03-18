using UnityEngine;
using System.Collections;

public class InventoryCharacterController : MonoBehaviour
{
  public Inventory Inventory;

  // Use this for initialization
  void Start()
  {
    Inventory.AddItem(0);
    Inventory.AddItem(1);
    Inventory.AddItem(1);
    Inventory.AddItem(0);
    Inventory.AddItem(1);
    Inventory.AddItem(1);
  }

  // Update is called once per frame
  void Update()
  {
  }
}