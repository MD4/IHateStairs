using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
  private Button[] _buttons;

  private Button _selected;

  // Use this for initialization
  void Start()
  {
    // Get all child buttons (inventory case)
    _buttons = GetComponentsInChildren<Button>();

    // Adding listeners
    foreach (var button in _buttons)
    {
      // Closure-like variable
      Button captured = button;
      button.onClick.AddListener(delegate { this.ButtonClicked(captured); });
    }
  }

  private void ButtonClicked(Button button)
  {
    Debug.Log(button.name);
    _selected = button;
    _selected.Select();
  }

  // Update is called once per frame
  void Update()
  {
  }
}