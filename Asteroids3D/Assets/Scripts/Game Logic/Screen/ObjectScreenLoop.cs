using UnityEngine;
using System.Collections;

public class ObjectScreenLoop : MonoBehaviour 
{

	//TO BE ATTACHED TO ANY LOOPABLE OBJECT ON THE SCREEN 
	//ALLOWS TO ANY OBJECT TO TRAVEL THROUGH TE SCREEN WITH LOOPING

	private bool hasRecentlyYLooped = false;
	private bool hasRecentlyXLooped = false;


	void Update()
	{
		
		//Allows for the ship to loop on the screen ( when objects hits the edge of level, it loops and starts moving from the opposite edge )
		if(transform.position.y > ScreenLoopTriggers.upperBoundary && !hasRecentlyYLooped )
		{
			hasRecentlyYLooped = true;
			transform.position = new Vector3(transform.position.x,ScreenLoopTriggers.lowerBoundary - (transform.localScale.y/2),0);
			StartCoroutine(resetLoopBool("Y"));
		}
		else if(transform.position.y < ScreenLoopTriggers.lowerBoundary && !hasRecentlyYLooped)
		{
			hasRecentlyYLooped = true;
			transform.position = new Vector3(transform.position.x,ScreenLoopTriggers.upperBoundary + (transform.localScale.y/2),0);
			StartCoroutine(resetLoopBool("Y"));
		}
		else if(transform.position.x < ScreenLoopTriggers.leftBoundary && !hasRecentlyXLooped)
		{
			hasRecentlyXLooped = true;
			transform.position = new Vector3(ScreenLoopTriggers.rightBoundary - (transform.localScale.y/2),transform.position.y,0);
			StartCoroutine(resetLoopBool("X"));
		}
		else if(transform.position.x > ScreenLoopTriggers.rightBoundary && !hasRecentlyXLooped)
		{
			hasRecentlyXLooped = true;
			transform.position = new Vector3(ScreenLoopTriggers.leftBoundary - (transform.localScale.y/2),transform.position.y,0);
			StartCoroutine(resetLoopBool("X"));
		}
		
	}

	//stops from objects to get stuck in the boundaries by adding delay to looping if recently it has been looped
	IEnumerator resetLoopBool(string axis)
	{
		yield return new WaitForSeconds(2f);
		
		if(axis == "Y")
		{
			hasRecentlyYLooped = false;
		}
		else if(axis == "X")
		{
			hasRecentlyXLooped = false;
		}
	}

}
