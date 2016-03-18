using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {

	public Transform goal;
	public Animator animator;
	public float attackDistance;
	public float agroDistance;

	private NavMeshAgent agent;
	private EnemyAttack attack;
	private EnemyHealth health;
	private bool aggro = false;

	void Start () {
	  animator = GetComponent<Animator>();
      agent = GetComponent<NavMeshAgent>();
      attack = GetComponent <EnemyAttack> ();
      health = GetComponent <EnemyHealth> ();
    }

    void Update() {
    	float distance = Vector3.Distance(transform.position, goal.transform.position);
    	if (agroDistance > distance) {
    		aggro = true;
    	}
    	if (aggro) {
    		agent.destination = goal.position;
			animator.SetBool("walk", true);
				if (distance > attackDistance && !(health.currentHealth <= 0)) {
				animator.SetBool("walk", true);
				attack.playerInRange = false;
			} else {
				animator.SetBool("walk", false);
				agent.destination = transform.position;
				attack.playerInRange = true;

			}
    	} else {
    		agent.destination = transform.position;
    	}
    }
}