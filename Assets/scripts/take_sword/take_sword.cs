using UnityEngine;
using System.Collections;

public class take_sword : MonoBehaviour {

    public GameObject helmet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "helmet")
        {
            Debug.Log("take sword");
            Destroy(this.gameObject);
            helmet.GetComponent<attach_sword>().hasSword = true;
        }
    }

}
