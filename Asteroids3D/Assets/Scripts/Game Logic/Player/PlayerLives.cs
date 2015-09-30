using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour 
{

	public static int playerLives = 3;
	public bool levelFailed = false;

	LevelManager levelManager;

	void Start()
	{
		levelManager = GetComponent<LevelManager>();
	}

	void Update()
	{
		if(playerLives < 0 && !levelFailed)
		{
			levelFailed = true;
			levelManager.LevelFailed();

			//RESET LIVE SOMEWHERE
		}

		if(playerLives > 3)
		{
			playerLives = 3;
		}
	}


}
