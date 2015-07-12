using UnityEngine;
using System.Collections;

public class AICannon : MonoBehaviour 
{

	private float nextFire = 3;

	[Header("AI Cannon Settings")]
	[SerializeField]
	private float fireRate = 0; //Set in inspector
	[SerializeField]
	private float fadeOutTime = 0.5f; //Set in inspector

	private bool findingTarget = false;
	private bool haveTarget = false;
	private bool fadeOutLine = false;
	private bool enableAI = true;

	private Transform currentTarget;
	private GameObject asteroidParent;

	private LineRenderer lineR;

	public bool EnableAI {
		get {
			return enableAI;
		}
		set {
			enableAI = value;
		}
	}

	void Start()
	{
		lineR = GetComponent<LineRenderer>();
		asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");

		findingTarget = false;
		haveTarget = false;
	}

	void Update()
	{
		if(enableAI)
		{
			//If no current target
			if(currentTarget == null)
			{
				haveTarget = false;
			}

			//Find target for AI cannon
			if(!findingTarget && !haveTarget)
			{
				if(asteroidParent.transform.childCount >= 1)
				{
					findingTarget = true;
					StartCoroutine(FindClosestAsteroid());

					Debug.Log("Closest Asteroid: " + currentTarget.gameObject.tag);
				}
			}

			if(haveTarget)
			{
				ShootAsteroid();
			}

			if(fadeOutLine)
			{
				//Set line render alpha ( lowering it )
				Material mat = lineR.material;
				Color color = mat.GetColor("_Color");
				color.a = Mathf.Lerp(color.a,0,fadeOutTime * Time.deltaTime);
				mat.SetColor("_Color",color);

				//Once alpha is below 0.2, reset line renderer to normal state
				if(color.a <= 0.2)
				{
					fadeOutLine = false;

					lineR.SetPosition(0,Vector3.zero);
					lineR.SetPosition(1,Vector3.zero);

					color.a = 1f;
					mat.SetColor("_Color",color);

				}

			}
		}
		else
		{
			Material mat = lineR.material;
			Color color = mat.GetColor("_Color");

			fadeOutLine = false;
			
			lineR.SetPosition(0,Vector3.zero);
			lineR.SetPosition(1,Vector3.zero);
			
			color.a = 1f;
			mat.SetColor("_Color",color);
		}
	}

	void ShootAsteroid()
	{
		//Shoot 
		if(Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

			lineR.SetPosition(0,transform.position);
			lineR.SetPosition(1,currentTarget.position);

			currentTarget.gameObject.SendMessage("DestroyAsteroid");

			fadeOutLine = true;
		}
	}

	IEnumerator FindClosestAsteroid()
	{
		//Find the closes target to the cannon to shoot at
		//Find squared distance rather than actual distance

		float currentDistance = Mathf.Infinity;

		foreach(Transform child in asteroidParent.transform)
		{

			Vector3 coordDiff = child.transform.position - transform.position;
			float sqrDistance = coordDiff.sqrMagnitude;

			if(sqrDistance < currentDistance)
			{
				currentDistance = sqrDistance;
				currentTarget = child;
			}
		}

		findingTarget = false;
		haveTarget = true;

		yield return new WaitForEndOfFrame();

	}


}
