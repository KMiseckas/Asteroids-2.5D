using UnityEngine;
using System.Collections;

public class RemoveLevelManager : MonoBehaviour 
{

	void Awake()
	{
		//When in non-level (actual gameplay) scene, remove unwanted level manager ( otherwise conflicts )
		if(GameObject.FindGameObjectWithTag("LevelManager"))
		{

			GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().CurrentLevel = 0;
			GameObject.FindGameObjectWithTag("LevelManager").SetActive(false);
		}
	}

}
