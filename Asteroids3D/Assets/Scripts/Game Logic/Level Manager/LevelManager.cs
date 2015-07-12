using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{

	//CURRENT AVAILABLE ASTEROIDS
	// - Normal_Large/Medium/Small
	// - Heavy_Large/Medium/Small
	// - Ice_Large/Medium/Small
	// - Diamond_Large/Medium/Small
	// -----------------------------
	public static bool isLevelBegginning = false;

	List<AsteroidsToSpawn> asteroidsToSpawn;

	[Header("Current Level + 1")]
	[SerializeField]
	private int currentLevel = 0;
	public static bool canStartLevel = true;

	public static int nextLevel;

	AsteroidSpawning spawnAsteroids;
	SaveObjectOverScene DontDestroyScript;

	void Start()
	{
		//Debug.Log("----------------NEW GAME STARTING---------------");

		DontDestroyScript = GetComponent<SaveObjectOverScene>();
		spawnAsteroids = GetComponent<AsteroidSpawning>();

		//Debug.Log("----------------NEW GAME INITIALIZED-------------");
	}

	void Update()
	{
		nextLevel = currentLevel + 1;

		if(canStartLevel)
		{
			StartNewLevel();
			canStartLevel = false;
		}
	}

	public void StartNewLevel()
	{
		if(GameObject.FindGameObjectWithTag("StoreManager") != null)
		{
			GameObject.FindGameObjectWithTag("StoreManager").GetComponent<Attachments>().SetAttachmentsToShip();
			Destroy(GameObject.FindGameObjectWithTag("StoreManager"));
		}

		//Debug.Log("STARTING ASTEROID SPAWNING");

		isLevelBegginning = true;

		//Check if spawnAsteroids component is not null
		CheckReferences();

		//List to send to the asteroid spawning script, contains the type and amount of asteroid to spawn
		//spawning of type and amount of asteroids depends on level player has reached

		asteroidsToSpawn = new List<AsteroidsToSpawn>();
		currentLevel ++;

		Debug.Log("CURRENT LEVEL = " + currentLevel);

		//Preset Levels
		#region LEVELS SETTINGS
		if(currentLevel < 5)
		{
			switch(currentLevel)
			{
			case 1:
				NewAsteroid("Normal_Medium",2);
				break;
			case 2:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			case 3:
				NewAsteroid("Normal_Medium",3);
				NewAsteroid("Normal_Small",4);
				break;
			case 4:
				NewAsteroid("Normal_Medium",4);
				NewAsteroid("Normal_Small",3);
				break;
			}


		}
		else if(currentLevel < 10 && currentLevel >= 5)
		{
			switch(currentLevel)
			{
			case 5:
				NewAsteroid("Normal_Large",3);
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			case 6:
				NewAsteroid("Normal_Large",5);
				NewAsteroid("Normal_Small",5);
				break;
			case 7:
				NewAsteroid("Normal_Large",4);
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",3);
				break;
			case 8:
				NewAsteroid("Normal_Large",5);
				NewAsteroid("Normal_Medium",4);
				NewAsteroid("Normal_Small",4);
				break;
			case 9:

				break;
			}

		}
		else if(currentLevel < 15 && currentLevel >= 10)
		{
			switch(currentLevel)
			{
			case 10:
				NewAsteroid("Normal_Large",3);
				NewAsteroid("Heavy_Medium",4);
				NewAsteroid("Normal_Small",2);
				break;
			case 11:
				NewAsteroid("Normal_Large",5);
				NewAsteroid("Heavy_Large",1);
				NewAsteroid("Normal_Small",2);
				break;
			case 12:
				NewAsteroid("Normal_Large",4);
				NewAsteroid("Heavy_Large",3);
				NewAsteroid("Heavy_Medium",2);
				break;
			case 13:
				NewAsteroid("Normal_Large",4);
				NewAsteroid("Heavy_Large",3);
				NewAsteroid("Normal_Small",6);
				break;
			case 14:
				NewAsteroid("Heavy_Large",6);
				NewAsteroid("Normal_Small",6);
				break;
			}

		}
		else if(currentLevel < 20 && currentLevel >= 15)
		{
			switch(currentLevel)
			{
			case 15:
				NewAsteroid("Heavy_Large",7);
				NewAsteroid("Heavy_Medium",1);
				break;
			case 16:
				NewAsteroid("Heavy_Large",2);
				NewAsteroid("Heavy_Medium",7);
				NewAsteroid("Normal_Small",3);
				break;
			case 17:
				NewAsteroid("Heavy_Medium",6);
				NewAsteroid("Normal_Small",5);
				NewAsteroid("Heavy_Small",3);
				break;
			case 18:
				NewAsteroid("Ice_Large",2);
				NewAsteroid("Heavy_Large",4);
				NewAsteroid("Heavy_Medium",3);
				NewAsteroid("Normal_Small",4);
				break;
			case 19:
				NewAsteroid("Ice_Large",4);
				NewAsteroid("Heavy_Large",4);
				NewAsteroid("Heavy_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			}

		}
		else if(currentLevel < 25 && currentLevel >= 20)
		{
			switch(currentLevel)
			{
			case 20:
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Heavy_Large",2);
				NewAsteroid("Heavy_Medium",3);
				break;
			case 21:
				NewAsteroid("Ice_Large",5);
				NewAsteroid("Ice_Medium",5);
				NewAsteroid("Heavy_Medium",4);
				NewAsteroid("Heavy_Small",5);
				break;
			case 22:
				NewAsteroid("Ice_Large",6);
				NewAsteroid("Heavy_Large",2);
				NewAsteroid("Ice_Medium",3);
				NewAsteroid("Heavy_Medium",1);
				break;
			case 23:
				NewAsteroid("Ice_Medium",9);
				NewAsteroid("Ice_Small",6);
				break;
			case 24:
				NewAsteroid("Ice_Large",8);
				NewAsteroid("Ice_Medium",5);
				break;
			}
			
		}
		else if(currentLevel < 30 && currentLevel >= 25)
		{
			switch(currentLevel)
			{
			case 25:
				NewAsteroid("Ice_Large",5);
				NewAsteroid("Diamond_Small",2);
				NewAsteroid("Ice_Medium",5);
				break;
			case 26:
				NewAsteroid("Diamond_Small",4);
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Ice_Medium",7);
				NewAsteroid("Ice_Small",4);
				break;
			case 27:
				NewAsteroid("Diamond_Medium",1);
				NewAsteroid("Diamond_Small",2);
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Ice_Medium",3);
				NewAsteroid("Ice_Small",4);
				break;
			case 28:
				NewAsteroid("Diamond_Medium",1);
				NewAsteroid("Diamond_Small",4);
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Ice_Medium",5);
				NewAsteroid("Ice_Small",2);
				break;
			case 29:
				NewAsteroid("Diamond_Large",1);
				NewAsteroid("Diamond_Small",5);
				NewAsteroid("Ice_Large",6);
				NewAsteroid("Ice_Medium",2);
				break;
			}
		}
		else if(currentLevel < 35 && currentLevel >= 30)
		{
			switch(currentLevel)
			{
			case 30:
				NewAsteroid("Diamond_Large",4);
				NewAsteroid("Ice_Large",4);
				NewAsteroid("Diamond_Medium",2);
				break;
			case 31:
				NewAsteroid("Diamond_Large",5);
				NewAsteroid("Ice_Large",4);
				NewAsteroid("Diamond_Medium",3);
				break;
			case 32:
				NewAsteroid("Diamond_Large",4);
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Ice_Medium",3);
				NewAsteroid("Diamond_Medium",2);
				break;
			case 33:
				NewAsteroid("Diamond_Large",4);
				NewAsteroid("Ice_Large",3);
				NewAsteroid("Ice_Medium",3);
				NewAsteroid("Diamond_Medium",2);
				NewAsteroid("Diamond_Small",3);
				break;
			case 34:
				NewAsteroid("Diamond_Large",5);
				NewAsteroid("Diamond_Medium",4);
				NewAsteroid("Diamond_Small",8);
				break;
			}
		}
		else if(currentLevel < 40 && currentLevel >= 35)
		{
			switch(currentLevel)
			{
			case 35:
				NewAsteroid("Normal_Medium",2);
				break;
			case 36:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			case 37:
				NewAsteroid("Normal_Medium",3);
				NewAsteroid("Normal_Small",1);
				break;
			case 38:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",3);
				break;
			case 39:

				break;
			}
		}
		else if(currentLevel < 45 && currentLevel >= 40)
		{
			switch(currentLevel)
			{
			case 40:
				NewAsteroid("Normal_Medium",2);
				break;
			case 41:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			case 42:
				NewAsteroid("Normal_Medium",3);
				NewAsteroid("Normal_Small",1);
				break;
			case 43:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",3);
				break;
			case 44:

				break;
			}
		}
		else if(currentLevel < 50 && currentLevel >= 45)
		{
			switch(currentLevel)
			{
			case 45:
				NewAsteroid("Normal_Medium",2);
				break;
			case 46:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",1);
				break;
			case 47:
				NewAsteroid("Normal_Medium",3);
				NewAsteroid("Normal_Small",1);
				break;
			case 48:
				NewAsteroid("Normal_Medium",2);
				NewAsteroid("Normal_Small",3);
				break;
			case 49:

				break;
			}
		}
		else if(currentLevel == 50)
		{

		}
		else if(currentLevel == 51)
		{
			//END GAME
		}
		#endregion

		//Send the list of asteroids to spawn to the spawning script
		spawnAsteroids.SpawnAsteroids(asteroidsToSpawn);

		//Enable the checking if level has been completed successfully
		LevelCheck.checkedReference = false;
		LevelCheck.checkIfSucceededLevel = true;

		//Debug.Log("FINISHED ASTEROID SPAWNING");
	}

	public void LevelSucceeded()
	{
		Debug.Log("LEVEL SUCCEEDED");

		Application.LoadLevel("LevelTransition");
	}

	public void LevelFailed()
	{
		currentLevel = 0;
		SaveAndResetScore();
		ResetCredits();
		//Go Main Menu
		//Destroy This Script

		Debug.Log("LEVEL FAILED");
	}

	void NewAsteroid(string asteroidType,int asteroidAmount)
	{
		asteroidsToSpawn.Add(new AsteroidsToSpawn(asteroidType,asteroidAmount));
	}

	void CheckReferences()
	{
		if(spawnAsteroids == null)
		{
			spawnAsteroids = GetComponent<AsteroidSpawning>();
		}
	}

	void SaveAndResetScore()
	{
		ScoreManager.score = 0;
	}

	void ResetCredits()
	{
		CreditData.currentCredit = 0;
	}


}
