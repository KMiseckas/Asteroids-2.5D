using UnityEngine;
using System.Collections;

public class ShipComponentManager : MonoBehaviour 
{
	//Ship Component Scripts
	AICannon cannon;
	UltraSound ultraSound;
	ControlTweaks controlTweaks;
	Shield shield;

	ShipShooting shootScript;

	void Awake()
	{
		cannon = GetComponent<AICannon>();
		ultraSound = GetComponent<UltraSound>();
		controlTweaks = GetComponent<ControlTweaks>();
		shield = GetComponent<Shield>();

		shootScript = GetComponent<ShipShooting>();
	}

	/// <summary>
	/// Adds the utility that is chosen onto the ship, only 1 utility active on ship
	/// </summary>
	/// <param name="utilityName">Utility name.</param>
	public void ActivateUtility(string utilityName)
	{
		switch(utilityName)
		{
		case "AICannon":
			cannon.enabled = true;

			controlTweaks.enabled = false;
			ultraSound.enabled = false;
			shield.enabled = false;
			break;
		case "Shield":
			shield.enabled = true;

			cannon.enabled = false;
			controlTweaks.enabled = false;
			ultraSound.enabled = false;
			break;
		case "UltraSound":
			ultraSound.enabled = true;

			cannon.enabled = false;
			controlTweaks.enabled = false;
			shield.enabled = false;
			break;
		case "CreditMagnet":


			cannon.enabled = false;
			controlTweaks.enabled = false;
			ultraSound.enabled = false;
			shield.enabled = false;
			break;
		case "ControlTweaks":
			controlTweaks.enabled = true;

			ultraSound.enabled = false;
			cannon.enabled = false;
			shield.enabled = false;
			break;
		case "Null":
			controlTweaks.enabled = false;
			ultraSound.enabled = false;
			cannon.enabled = false;
			shield.enabled = false;
			break;
		}
	}

	/// <summary>
	/// Activates the weapon chosen for the ship
	/// </summary>
	/// <param name="weaponName">Weapon name.</param>
	public void ActivateMainWeapon(string weaponName)
	{
		shootScript.WeaponType = weaponName;
	}

	/// <summary>
	/// Activates the special ability chosen for the ship
	/// </summary>
	/// <param name="abilityName">Ability name.</param>
	public void ActivateSpecialAbility(string abilityName)
	{
		shootScript.SecWeaponType = abilityName;
	}

}
