using UnityEngine;
using System.Collections;

public class Attachments : MonoBehaviour
{

	private string primaryWeapon = "Single_Fire";
	private string seconderyWeapon;
	private string specialAbility;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void SetPrimaryWeapon(string primary)
	{
		primaryWeapon = primary;
	}

	public void SetSeconderyWeapon(string secondery)
	{
		seconderyWeapon = secondery;
	}

	public void SetSpecialAbility(string special)
	{
		specialAbility = special;
	}

	public void SetAttachmentsToShip()
	{
		ShipComponentManager shipComponents = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipComponentManager>();

		shipComponents.ActivateMainWeapon(primaryWeapon);
		shipComponents.ActivateSpecialAbility(seconderyWeapon);
		shipComponents.ActivateUtility(specialAbility);
	}

}
