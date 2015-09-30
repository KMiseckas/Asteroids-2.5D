using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighScore : MonoBehaviour 
{

	void Start()
	{
		GetComponent<Text> ().text = "HighScore: " + PlayerPrefs.GetFloat ("HighScore", 0);
	}

}
