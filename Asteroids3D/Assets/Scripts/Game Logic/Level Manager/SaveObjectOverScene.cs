using UnityEngine;
using System.Collections;

public class SaveObjectOverScene : MonoBehaviour 
{

	//Saves all components on current object with this script attached over to the next scene
	//Allows all stats to be reused from previous scenes

	public static bool newInstanceCreated = false;

	void Awake()
	{
			//Debug.LogError("dontdestroy start");
			if(!newInstanceCreated)
			{
				DontDestroyOnLoad(this.gameObject);
				newInstanceCreated = true;
			}
			else
			{
				Destroy(this.gameObject);
				LevelManager.canStartLevel = true;
			}
			//Debug.LogError("dontdestroy end");
	}


}
