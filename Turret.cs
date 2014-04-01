using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public Transform Target;
	public float damp = 6.0f;
	public Transform bulletPrefab;
	public float nextShotTime = 0.0f;
	public float timeBetweenShots = 2.0f;
	public float MaxRange = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


			Target= GameObject.FindGameObjectWithTag("Balloon").transform;
			float Distance = Vector3.Distance(Target.position, transform.position);
			Debug.Log(Distance);
						if (Distance < MaxRange) {
								transform.LookAt (Target.position);	
								if (nextShotTime <= Time.time) {
										Debug.Log ("SHOOOT");
										Shoot ();
										nextShotTime = Time.time + timeBetweenShots;
								}
						}
				
	}
	void Shoot()
	{	
		Vector3 bulletPosition= new Vector3(bulletPrefab.position.x, bulletPrefab.position.y, -1); 
		Transform bullet = (Transform)Instantiate(bulletPrefab, bulletPosition, transform.rotation);
		//bullet.rotation = transform.rotation;
		bullet.rigidbody.AddForce(transform.forward * 1000);
	}


		void Assert(bool condition)
	{
		if(!condition)
		{
			Debug.LogError("Error");
		}

	}
}