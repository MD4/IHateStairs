using UnityEngine;

public class MenuListener : MonoBehaviour
{


  public void OnClick(string name)
  {
    Debug.Log(name + " clicked");
    switch (name)
    {
      case "PLAY":
        Application.LoadLevel("main");
        break;
      case "OPTIONS":
        break;
      case "EXIT":
        Application.Quit();
        break;
    }

  }
}