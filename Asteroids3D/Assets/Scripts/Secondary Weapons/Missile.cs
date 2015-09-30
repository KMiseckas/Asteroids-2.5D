using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour 
{
	private GameObject asteroidParent;

	private float lowestDistance = 0;
	private float missileForce = 0;
	//private float missileSmoothness = 0;
	private bool isCheckDone = false;

	private Transform currentTransform;

	private Rigidbody rigidBody;
	
	#region properties
	public float MissileForce 
	{
		get {return missileForce;}
		set {missileForce = value;}
	}

	#endregion

	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();

		asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");

		FindNearestAsteroid();
	}

	void LateUpdate()
	{
		if(isCheckDone)
		{
			if(currentTransform != null)
			{
				//Follow the asteroid target with constant speed
				transform.LookAt(currentTransform.position,transform.up);

				rigidBody.AddForce(transform.forward * missileForce);
				
				if(rigidBody.velocity.magnitude >= missileForce)
				{
					rigidBody.velocity = rigidBody.velocity.normalized * missileForce;
				}
			}
			else
			{
				//if no current transform to follow, find a new one
				FindNearestAsteroid();
			}
		}
	}

	void FindNearestAsteroid()
	{
		//Find the nearest asteroid to the missile using for each child in asteroid parent method
		isCheckDone = false;

		foreach(Transform asteroid in asteroidParent.transform)
		{
			float distance = Vector3.Distance(transform.position,asteroid.position);
			
			if(lowestDistance == 0)
			{
				lowestDistance = distance;
			}
			
			if(lowestDistance >= distance)
			{
				lowestDistance = distance;
				currentTransform = asteroid;
			}
		}

		isCheckDone = true;
	}

}
