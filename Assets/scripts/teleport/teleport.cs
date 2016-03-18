using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {

    public string nextSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Application.LoadLevel(nextSceneName);
    }
}
