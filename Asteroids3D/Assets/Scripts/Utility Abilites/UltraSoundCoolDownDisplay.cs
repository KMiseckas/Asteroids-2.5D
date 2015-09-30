using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UltraSoundCoolDownDisplay : MonoBehaviour 
{

	Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
	{
		text.text = "UltraSound: " + UltraSound.currentCoolDown + "%";
	}
}
