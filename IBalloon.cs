using UnityEngine;
using System.Collections;

public interface IBalloon 
{
	void Start ();
	void Update ();
	void ChangePosition();
	void OnTriggerEnter (Collider collider);
}
