using UnityEngine;
using System.Collections;

public interface ITurret  
{
	void Start ();
	void Update ();
    void Shoot();
    GameObject findClosestTarget();
}
