using UnityEngine;
using System.Collections;

public class ScreenLoopTriggers: MonoBehaviour 
{
	//[Header("Level Barrier")]
	//public GameObject upperBarrier;
	//public GameObject lowerBarrier;
	//public GameObject leftBarrier;
	//public GameObject rightBarrier;

	public static float upperBoundary;
	public static float lowerBoundary;
	public static float leftBoundary;
	public static float rightBoundary;


	void Start()
	{
		float mainCamHeight = Camera.main.orthographicSize;
		Vector3 mainCamPos = Camera.main.transform.position;
		float mainCamWidth = mainCamHeight * Camera.main.aspect;

		//Set up triggers in correct positions if needed
		//upperBarrier.gameObject.transform.position = new Vector3(mainCamPos.x,mainCamPos.y + mainCamHeight + upperBarrier.gameObject.transform.localScale.y/2,0);
		//lowerBarrier.gameObject.transform.position = new Vector3(mainCamPos.x,mainCamPos.y - mainCamHeight - lowerBarrier.gameObject.transform.localScale.y/2,0);
		//leftBarrier.gameObject.transform.position = new Vector3(mainCamPos.x - mainCamWidth - leftBarrier.gameObject.transform.localScale.y/2,mainCamPos.y,0);
		//rightBarrier.gameObject.transform.position = new Vector3(mainCamPos.x + mainCamWidth + rightBarrier.gameObject.transform.localScale.y/2,mainCamPos.y,0);

		//Set up boundaries
		upperBoundary = mainCamPos.y + mainCamHeight;
		lowerBoundary = mainCamPos.y - mainCamHeight;
		leftBoundary = mainCamPos.x - mainCamWidth;
		rightBoundary = mainCamPos.x + mainCamWidth;
	}
}
