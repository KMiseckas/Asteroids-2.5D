using UnityEngine;
using System.Collections;

public class ShipComponentManager : MonoBehaviour 
{

	AICannon cannon;
	UltraSound ultraSound;
	ControlTweaks controlT;
	Shield shield;

	ShipShooting shootScript;

	void Awake()
	{
		cannon = GetComponent<AICannon>();
		ultraSound = GetComponent<UltraSound>();
		controlT = GetComponent<ControlTweaks>();
		shield = GetComponent<Shield>();

		shootScript = GetComponent<ShipShooting>();
	}

	public void ActivateUtility(string utilityName)
	{
		switch(utilityName)
		{
		case "AICannon":
			cannon.enabled = true;

			controlT.enabled = false;
			ultraSound.enabled = false;
			shield.enabled = false;
			break;
		case "Shield":
			shield.enabled = true;

			cannon.enabled = false;
			controlT.enabled = false;
			ultraSound.enabled = false;
			break;
		case "UltraSound":
			ultraSound.enabled = true;

			cannon.enabled = false;
			controlT.enabled = false;
			shield.enabled = false;
			break;
		case "CreditMagnet":


			cannon.enabled = false;
			controlT.enabled = false;
			ultraSound.enabled = false;
			shield.enabled = false;
			break;
		case "ControlTweaks":
			controlT.enabled = true;

			ultraSound.enabled = false;
			cannon.enabled = false;
			shield.enabled = false;
			break;
		case "Null":
			controlT.enabled = false;
			ultraSound.enabled = false;
			cannon.enabled = false;
			shield.enabled = false;
			break;
		}
	}

	public void ActivateMainWeapon(string weaponName)
	{
		shootScript.WeaponType = weaponName;
	}

	public void ActivateSpecialAbility(string abilityName)
	{
		shootScript.SecWeaponType = abilityName;
	}

}
