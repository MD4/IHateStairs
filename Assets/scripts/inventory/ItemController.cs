using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
  private InventoryItem _item;
  private Image _itemImage;
  private Inventory inventory;

  private PlayerHealth playerHealth;
  // Use this for initialization
  void Start()
  {
    playerHealth = FindObjectOfType<PlayerHealth>();
    inventory = FindObjectOfType<Inventory>();
    _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
  }

  // Update is called once per frame
  void Update()
  {
    if (_item != null)
    {
      _itemImage.enabled = true;
      _itemImage.sprite = _item.ItemIcon;
    }
    else
    {
      _itemImage.enabled = false;
    }
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    Debug.Log("Entered");
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    Debug.Log("Clicked" + transform.name);
    if (_item != null && _item.Type == InventoryItem.ItemType.Consumable)
    {
      if (_item.Name == "potion-item")
      {
        playerHealth.TakeHeal(20);
      }

      inventory.Remove(transform.name);
    }
  }

  public InventoryItem Item
  {
    get { return _item; }
    set { _item = value; }
  }
}