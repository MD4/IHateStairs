using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {

	public Transform goal;
	public Animator animator;
	public float attackDistance;

	private NavMeshAgent agent;
	private EnemyAttack attack;
	private EnemyHealth health;

	void Start () {
	  animator = GetComponent<Animator>();
      agent = GetComponent<NavMeshAgent>();
      attack = GetComponent <EnemyAttack> ();
      health = GetComponent <EnemyHealth> ();
    }

    void Update() {
       	agent.destination = goal.position;
		animator.SetBool("walk", true);
		float distance = Vector3.Distance(transform.position, goal.transform.position);
		if (distance > attackDistance && !(health.currentHealth <= 0)) {
			animator.SetBool("walk", true);
			attack.playerInRange = false;
		} else {
			animator.SetBool("walk", false);
			agent.destination = transform.position;
			attack.playerInRange = true;

		}
    }
}