using UnityEngine;

using System.Collections;



public class MoveToTargetTest : MonoBehaviour {
	
	public float speed = 4f;
	public Transform wayPoint;
	public Transform[] wayPointArray;
	private int wayPointIndex_=0;
	// Use this for initialization
	void Start () 
	{
		wayPoint = wayPointArray [wayPointIndex_];
	}

	// Update is called once per frame
	void Update () {
		if (wayPointIndex_ < wayPointArray.Length) 
		{
			ChangePosition ();
		}
		else
		{
			Destroy(gameObject);
		}

	}
	void ChangePosition()
	{
		if(wayPoint)

			transform.position = Vector3.MoveTowards(transform.position, wayPoint.transform.position, speed * Time.deltaTime);
	}
	void OnTriggerEnter ()
	{
		wayPointIndex_++;  
		wayPoint = wayPointArray [wayPointIndex_];

	}
	
}