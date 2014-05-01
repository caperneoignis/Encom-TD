using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour, ITurret
{
	public bool moveable_ = true;
	public bool targetFound_ = false;
	public Transform bulletPrefab_;
	public Vector3 targetToLookAt_ = new Vector3(0f, 0f, 0f);
	public Vector3 targetVelocity_ = new Vector3 (0f, 0f, 0f);
	public Vector3 turretPosition_;
	public float nextShotTime_ = 0.0f;
	public float timeBetweenShots_ = 2.0f;
	public float maxRange_ = 5.0f;
	public int bulletForce_ = 1000;
	private string targetTag_ = "Balloon";
	public float zLocation_ = -1.0f;
	const float PHYSICS_CONST = .1f;
	public float targetSpeed_ = 0f;
	public float bulletVelocity_;

	// Use this for initialization
	public void Start () {
		CalculateBulletVelocity ();
	}
	
	// Update is called once per frame
	public void Update () 
	{

		GameObject Target = findClosestTarget ();
		if (Target != null) 
		{
			StartCoroutine(CalcVelocity(Target));
			CalculateDistance(Target);
			targetToLookAt_ = PositionToShootAt(Target);
			transform.LookAt (targetToLookAt_);
			/*Debug.Log("targets");
			Debug.Log(Target.transform.position);
			Debug.Log (targetSpeed_);
			Debug.Log (CalculateDistance(Target));
			Debug.Log (bulletVelocity_);
			Debug.Log (targetVelocity_);
			Debug.Log(targetToLookAt_);*/

			if (nextShotTime_ <= Time.time) 
			{
				Shoot ();
				nextShotTime_ = Time.time + timeBetweenShots_;
			}
		}
	}
				

	public void Shoot()
	{	
			Vector3 bulletPosition = new Vector3 (bulletPrefab_.position.x, bulletPrefab_.position.y, zLocation_); 
			Transform bullet = (Transform)Instantiate (bulletPrefab_, bulletPosition, transform.rotation);
			bullet.rigidbody.AddForce (transform.forward * bulletForce_);
	}

	public GameObject findClosestTarget()
	{
		GameObject[] allBalloons_= GameObject.FindGameObjectsWithTag(targetTag_);
		float Distance;
		GameObject Target=null;
		int size = allBalloons_.Length;
		int i = 0;
		while (i<size && Target==null) 
		{
			Distance = Vector3.Distance(allBalloons_[i].transform.position, transform.position);
			if (Distance < maxRange_) 
			{
				Target=allBalloons_[i];
			}
			i++;
		}
		return Target;
	}
	
	public IEnumerator CalcVelocity(GameObject target)
	{
		targetFound_ = false;
		// Position at frame start
		Vector3 prevPos = target.transform.position;
		// Wait till it the end of the frame
		yield return new WaitForEndOfFrame();
		// Calculate velocity: Velocity = DeltaPosition / DeltaTime
		targetVelocity_ = -((prevPos - target.transform.position) / Time.deltaTime);
		targetSpeed_ = Vector3.Distance (prevPos, target.transform.position) / Time.deltaTime;
		targetFound_ = true;
	}

	public void CalculateBulletVelocity()
	{
		bulletVelocity_ = bulletForce_ * PHYSICS_CONST;
	}

	public float CalculateDistance(GameObject target)
	{
		float distance = 0f;
		distance = Vector3.Distance(target.transform.position, transform.position);
		return distance;
	}
	
	public Vector3 PositionToShootAt(GameObject target)
	{
		Vector3 position = target.transform.position;
		position += (targetSpeed_ * (CalculateDistance(target)/bulletVelocity_)) * targetVelocity_;
		return position;
	}
}
