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
    }
}