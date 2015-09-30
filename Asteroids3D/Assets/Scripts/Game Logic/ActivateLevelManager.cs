using UnityEngine;
using System.Collections;

public class ActivateLevelManager : MonoBehaviour 
{
	public void Activate()
	{
		if(Application.loadedLevelName != "Menu" && !this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(true);
		}
	}
}
