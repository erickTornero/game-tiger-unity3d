using UnityEngine;
using System.Collections;

public class ShotHit : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Hit");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
