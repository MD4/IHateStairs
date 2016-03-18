using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class move : MonoBehaviour {

	float v = 0;
	float h = 0;

	public float speed = 0;
	public float turnSpeed = 2;
	public Transform transform;
	public CharacterController characterController;
	public Animator animator;
	public float angle;
	private bool b = false;
	public int damage = 50;

	public List<EnemyHealth> ennemyList;
	public AudioClip attackClip;
	AudioSource playerAudio;

	// Use this for initialization
	void Start () {
		this.characterController = gameObject.GetComponent<CharacterController> ();
		ennemyList = new List<EnemyHealth>();
		playerAudio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");

		angle -= h * turnSpeed * Time.deltaTime;

		transform.localEulerAngles = new Vector3 (0, (Mathf.PI / 2 - angle) * (180 / Mathf.PI), 0);

		characterController.Move (new Vector3 (
			Mathf.Cos(angle) * v * speed * Time.deltaTime,
			-30f * Time.deltaTime,
			Mathf.Sin(angle) * v * speed * Time.deltaTime
		));

		animator.SetInteger ("moving", (v != 0) ? 1 : 0);

		float attack = Input.GetAxis("Fire1");

		animator.SetInteger ("attacking", (attack != 0) ? 1 : 0);
		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack_sword")) {
			if (b == false)
				at();
		}
		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("idle_sword")) {
			b = false;
		}
		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk")) {
			b = false;
		}
	}

	void at ()  {
		Debug.Log("boom");
		foreach(var ennemy in ennemyList) {
			ennemy.TakeDamage(damage);
			playerAudio.clip = attackClip;
    		playerAudio.Play();
		}
		b = true;
	}
}
