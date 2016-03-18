using UnityEngine;
using System.Collections;

public class attach_sword : MonoBehaviour {

    public GameObject sword;
    public GameObject bone;
    public bool hasSword = false;

    void Start () {
	    
	}
	
	void Update () {
        if (hasSword)
        {
            sword.transform.parent = bone.transform;
            sword.transform.localPosition = Vector3.zero;
            sword.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
