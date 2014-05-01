using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour, IBalloon
{
	public Vector3 initialPosition_= new Vector3(-10.0f, -.4f, -1.0f);
	public float speed_ = 5f;
	public Transform wayPoint_;
	public Transform[] wayPointArray_;
	private int wayPointIndex_=0;
	// Use this for initialization
	public void Start () 
	{
		transform.position = initialPosition_;
		collider.isTrigger = false;
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
		wayPoint_ = wayPointArray_ [wayPointIndex_];
	}

	// Update is called once per frame
	public void Update () {
		if (wayPointIndex_ < wayPointArray_.Length) 
		{
			ChangePosition ();
		}
		else
		{	
			Destroy(gameObject);
		}

		//TEST
		//Assert (wayPointIndex_ <= wayPointArray.Length);
		//Assert (rigidbody.velocity.x == speed || rigidbody.velocity.y == speed);
	}
	public void ChangePosition()
	{
		if (wayPoint_) 
		{
			transform.position = Vector3.MoveTowards (transform.position, wayPoint_.transform.position, speed_ * Time.deltaTime);
		}
	}
	public void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.tag == "Turn") {
			wayPointIndex_++;  
			wayPoint_ = wayPointArray_ [wayPointIndex_];
			}
		if (collider.gameObject.tag == "Bullet") {
			Destroy(gameObject);	
			//Destroy(collider);
			MainGame.totalScore_++;
		}
		if (collider.gameObject.tag == "EndOfLine") {
			Destroy(gameObject);	
			//Destroy(collider);
			MainGame.lives_--;
		}
	}

	public void Assert(bool condition)
	{
		if(!condition)
		{
			//Debug.LogError("Error");
		}
		
	}
}