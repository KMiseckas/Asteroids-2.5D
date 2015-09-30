using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowEndGameScore : MonoBehaviour 
{
	//Use this class to save score value before reseting it so it can be displayed on the game win panel at the end of the game

	public GameObject textObject;

	private Text scoreText;
	private float score = 0;
	
	void Start()
	{
		scoreText = textObject.GetComponent<Text>();
	}
	
	public void GetScore()
	{
		score = ScoreManager.score;
	}

	public void DisplayScore()
	{
		scoreText.text = score.ToString();
	}
}
