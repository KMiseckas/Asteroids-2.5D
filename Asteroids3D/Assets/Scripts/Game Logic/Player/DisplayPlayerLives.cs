using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPlayerLives : MonoBehaviour 
{

	private Text livesText;
	
	void Start()
	{
		livesText = GetComponent<Text>();
	}
	
	void Update()
	{
		if(PlayerLives.playerLives >=0)
		{
			livesText.text = "Lives: " + PlayerLives.playerLives;
		}
		else
		{
			livesText.text = "Lives: " + 0;
		}
	}

}
