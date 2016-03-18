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
        if(col.gameObject && (col.gameObject.name == "dragon" || col.gameObject.name == "minotaure" || col.gameObject.name == "minotaure (1)")) {
        	EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
         	m.ennemyList.Add(enemyHealth);
         	Debug.Log("enter");
        }
    }

    void OnTriggerExit(Collider col)
	{
	    if(col.gameObject && col.gameObject.name == "dragon") {
        	EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
        	m.ennemyList.Remove(enemyHealth);
        	Debug.Log("exit");
        }
	}
}
