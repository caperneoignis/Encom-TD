using UnityEngine;
using System.Collections;

public class ForceTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (transform.forward * 1000);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.LogError(rigidbody.velocity);
	}
}
