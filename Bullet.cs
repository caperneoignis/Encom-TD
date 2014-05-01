using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.tag == "Balloon") {
			Destroy(gameObject);	
		}
	}
}
