using UnityEngine;
using System.Collections;

public class TurretTest : MonoBehaviour {
	public Vector3 zero_ = new Vector3(0,0,0);
	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		float nextShotTime_ = 2f;
		GameObject testTarget = findClosestTarget();

		if (testTarget != null) 
		{
			transform.LookAt (testTarget.transform.position);	
			if (nextShotTime_ <= Time.time) {
				Debug.Log ("SHOOOT");
				Shoot ();
				nextShotTime_ = Time.time + 0;
			}
		}

	}
	public void Shoot()
	{
		Vector3 bulletPosition= new Vector3(0,0,0); 

	}
	
	public GameObject findClosestTarget()
	{
		GameObject testReturn = null;
		testReturn.transform.position = zero_;
		return testReturn;
	}
}
