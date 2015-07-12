using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScoreUI : MonoBehaviour 
{

	private Text scoreText;

	void Start()
	{
		scoreText = GetComponent<Text>();
	}

	void Update()
	{
		scoreText.text = "Score: " + ScoreManager.score;
	}

}
