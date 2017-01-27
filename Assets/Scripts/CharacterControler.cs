using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {
	static Animator anim;
	public float speed = 10.0f;
	void Start () {
		anim = GetComponent<Animator> ();
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;
		transform.Translate (straffe, 0, translation);
		if (Input.GetButton ("Fire1")) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
		if (translation != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isIdle", false);
		} else {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isIdle", true);
		}
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
