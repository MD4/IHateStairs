using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	float v = 0;
	float h = 0;

	public float speed = 0;
	public float turnSpeed = 2;
	public Transform transform;
	public CharacterController characterController;
	public Animator animator;
	public float angle;

	// Use this for initialization
	void Start () {
		this.characterController = gameObject.GetComponent<CharacterController> ();
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
	}
}
