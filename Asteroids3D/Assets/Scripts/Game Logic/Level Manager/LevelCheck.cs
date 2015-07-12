using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour 
{

	private GameObject asteroidParent;
	public static bool checkIfSucceededLevel = false;
	public static bool checkedReference = false;

	LevelManager levelManager;

	void Start()
	{
		levelManager = GetComponent<LevelManager>();
	}

	void Update()
	{
		if(checkIfSucceededLevel)
		{
			if(!checkedReference)
			{
				CheckReference();
			}

			//Check asteroidParent, if its empty, the level has been succesfully completed ( unless player lost all lives before )
			if(asteroidParent.transform.childCount <= 0 && PlayerLives.playerLives >= 0)
			{
				checkIfSucceededLevel = false;

				Debug.Log("CHECKED: LEVEL COMPLETED");
				levelManager.LevelSucceeded();
			}
		}
	}

	void CheckReference()
	{
		asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");
		checkedReference = true;
	}

}
