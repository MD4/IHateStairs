using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {

	public Transform goal;
	public Animator animator;
	public float attackDistance;

	private NavMeshAgent agent;

	void Start () {
	  animator = GetComponent<Animator>();
      agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
       	agent.destination = goal.position;
		animator.SetBool("walk", true);
		float distance = Vector3.Distance(transform.position, goal.transform.position);
		if (distance > attackDistance) {
			Debug.Log(distance);
			animator.SetBool("walk", true);
		} else {
			Debug.Log(distance);
			animator.SetBool("walk", false);
			agent.destination = transform.position;
		}
    }
}