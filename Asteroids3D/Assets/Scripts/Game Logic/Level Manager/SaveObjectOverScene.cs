using UnityEngine;
using System.Collections;

public class SaveObjectOverScene : MonoBehaviour 
{
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
