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
		//Checks if game level has been finished every 0.2 seconds ( slower than Update());
		levelManager = GetComponent<LevelManager>();
		InvokeRepeating ("SlowUpdate", 0, 0.2f);
	}

	void SlowUpdate()
	{
		if(Application.loadedLevelName != "Menu" && !this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(true);
			checkIfSucceededLevel = true;
		}

		if(checkIfSucceededLevel)
		{
			if(!checkedReference)
			{
				CheckReference();
			}

			if(Application.loadedLevel == 1)
			{
				//Check asteroidParent, if its empty, the level has been succesfully completed ( unless player lost all lives before )
				if(asteroidParent && asteroidParent.transform.childCount <= 0 )
					if(PlayerLives.playerLives >= 0)
				{
					{
						checkIfSucceededLevel = false;

						//Debug.Log("CHECKED: LEVEL COMPLETED");
						levelManager.LevelSucceeded();
					}
				}
			}
		}
	}

	void CheckReference()
	{
		asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");
		checkedReference = true;
	}

}
