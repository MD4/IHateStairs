using UnityEngine;

[System.Serializable]
public class InventoryItem
{
  public int ItemId { get; set; }
  public string Name { get; set; }
  public string Desc { get; set; }
  public ItemType Type { get; set; }
  public Sprite ItemIcon { get; set; }
  public GameObject modelObject;

  public enum ItemType
  {
    Weapon,
    Consumable,
    Other
  }

  public InventoryItem(int itemId, string name, string desc, ItemType type)
  {
    ItemId = itemId;
    Name = name;
    Desc = desc;
    Type = type;
    ItemIcon  = Resources.Load<Sprite>("" + name);
  }

  public InventoryItem()
  {
  }
}