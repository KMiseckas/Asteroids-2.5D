using UnityEngine;
using System.Collections;

public class ButtonMethods : MonoBehaviour
{

	public void SwitchScene(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}

	public void MuteVolume()
	{

	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
