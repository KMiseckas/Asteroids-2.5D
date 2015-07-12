using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour 
{

	public static int playerLives = 3;

	LevelManager levelManager;

	void Start()
	{
		levelManager = GetComponent<LevelManager>();
	}

	void Update()
	{
		if(playerLives < 0)
		{
			levelManager.LevelFailed();

			//RESET LIVE SOMEWHERE
		}

		if(playerLives > 3)
		{
			playerLives = 3;
		}
	}


}
