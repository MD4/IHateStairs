using UnityEngine;
using System.Collections;

public class attach_sword : MonoBehaviour {

    public GameObject sword;
    public GameObject bone;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        sword.transform.parent = bone.transform;
        sword.transform.localPosition = Vector3.zero;
        sword.transform.localRotation = Quaternion.identity;
        //var someTransform = sword.transform;
        //sword.parent = bone;
        //sword.localPosition = Vector3.zero;
        //sword.localRotation = Quaternion.identity;
        //sword.localScale = Vector3.one;
    }
}
