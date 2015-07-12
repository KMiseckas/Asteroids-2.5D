using UnityEngine;
using System.Collections;

public class CreditPickUp : MonoBehaviour 
{

	[Header("Credit Values")]
	[SerializeField]
	private int smallCredit = 0; //Set in inspector
	[SerializeField]
	private int mediumCredit = 0; //Set in inspector
	[SerializeField]
	private int largeCredit = 0; //Set in inspector
	[SerializeField]
	private int diamondCredit = 0; //Set in inspector

	void OnTriggerEnter(Collider col)
	{
		//Add credit dependant on credit type ( tag )
		switch(col.gameObject.tag)
		{
		case "SmallCredit":
			Destroy(col.gameObject);
			CreditData.currentCredit += smallCredit;
			//SOUND
			break;
		case "MediumCredit":
			Destroy(col.gameObject);
			CreditData.currentCredit += mediumCredit;
			//SOUND
			break;
		case "LargeCredit":
			Destroy(col.gameObject);
			CreditData.currentCredit += largeCredit;
			//SOUND
			break;
		case "DiamondCredit":
			Destroy(col.gameObject);
			CreditData.currentCredit += diamondCredit;
			//SOUND
			break;
		default:

			break;
		}
	}

}
