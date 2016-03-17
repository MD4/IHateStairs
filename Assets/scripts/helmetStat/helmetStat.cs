using UnityEngine;
using System.Collections;

public class helmetStat : MonoBehaviour {

	public int pvMax;
	public int pv;

	// Use this for initialization
	void Start () {
		pv = pvMax;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void TakeDamage (int damage) {
		pv = pv - damage;
	}
}
