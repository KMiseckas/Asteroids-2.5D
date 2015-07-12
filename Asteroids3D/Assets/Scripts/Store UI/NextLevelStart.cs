using UnityEngine;
using System.Collections;

public class NextLevelStart : MonoBehaviour 
{

	public void StartNextLevel()
	{
		Application.LoadLevel("Asteroids");
	}

}
