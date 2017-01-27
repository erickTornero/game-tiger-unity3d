using UnityEngine;
using System.Collections;

public class TigerWalk : MonoBehaviour {

	public Transform player;
	static Animator anim;
	public float velocidadCaminata = 1.0f;
	public float translation;
	public float velocidadDeSalto = 0;
	private bool isJumping=false;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isJumping) {
			translation = Input.GetAxis ("Vertical") * velocidadCaminata;
			float straffe = Input.GetAxis ("Horizontal") * velocidadCaminata;
			translation *= Time.deltaTime;
			straffe *= Time.deltaTime;
			transform.Translate (straffe, 0, translation);
			if (Input.GetButton ("Fire1")) {
				anim.SetBool ("rugir", true);
			} else {
				anim.SetBool ("rugir", false);
			}
			if (translation != 0) {
				anim.SetBool ("parar", false);
				anim.SetBool ("rugir", false);
				anim.SetBool ("caminar", true);
			} else {
				anim.SetBool ("caminar", false);
				anim.SetBool ("parar", true);
			}
			if (Input.GetKeyDown ("escape")) {
				Cursor.lockState = CursorLockMode.None;
			}
			if (Input.GetButton ("Jump")) {
				applyForce (new Vector3 (0, 20, 0));
				//StartCoroutine (saltar ());
			}
		}
	}

	IEnumerator saltar ()
	{
		isJumping = true;
		translation = Input.GetAxis ("Vertical");
		for (int x = 0; x < 200; x++) {
			transform.Translate (0, 0.1f, translation);
			yield return new WaitForEndOfFrame();
		}
		isJumping = false;
	}
	public void applyForce(Vector3 force){
				this.transform.GetComponent<Rigidbody>().AddForce(force);
	}
}
