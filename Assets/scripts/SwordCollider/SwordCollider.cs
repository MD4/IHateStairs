using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

	public GameObject helmet;
	private move m;

	// Use this for initialization
	void Start () {
		m = helmet.GetComponent <move> ();
	
	}
	
	void OnTriggerEnter (Collider col)
    {
        if(col.gameObject && col.gameObject.name == "dragon") {
        	EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
         	m.ennemyList.Add(enemyHealth);
        }
    }

    void OnTriggerExit(Collider col)
	{
	    if(col.gameObject && col.gameObject.name == "dragon") {
        	EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
        	m.ennemyList.Remove(enemyHealth);
        }
	}
}
