using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour 
{
	bool isPaused = false;
	public static bool isPauseEnabled = true;

	public GameObject pauseText;

	PlayerShipMovement movement;

	void Start()
	{
		pauseText.SetActive (false);
		movement = GetComponent<PlayerShipMovement> ();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
		{
			if(isPauseEnabled)
			{
				if(!isPaused)
				{
					Time.timeScale = 0;
					pauseText.SetActive(true);
					movement.MovementEnabled = false;
					isPaused = true;
				}
				else
				{
					Time.timeScale = 1;
					pauseText.SetActive(false);
					movement.MovementEnabled = true;
					isPaused = false;
				}
			}
		}
	}

}
