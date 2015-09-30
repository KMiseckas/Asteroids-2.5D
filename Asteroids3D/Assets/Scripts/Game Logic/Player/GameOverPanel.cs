using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour 
{

	public Text highScore;
	public Text currentScore;
	public Text newHighScore;


	public void RefreshGameOverText(float highScoreVal,float score)
	{
		highScore.text = "HighScore: " + highScoreVal;
		currentScore.text = "Your Score: " + score;

		if(score >= highScoreVal)
		{
			newHighScore.text = "New HighScore!";
		}
		else
		{
			newHighScore.text = "Try again";
		}
	}
}
