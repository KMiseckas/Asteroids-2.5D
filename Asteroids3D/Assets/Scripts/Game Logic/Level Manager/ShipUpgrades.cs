using UnityEngine;
using System.Collections;

public class ShipUpgrades : MonoBehaviour 
{

	[Header("Bought Upgrades")]
	public bool singleFire = true;
	public bool doubleFire = false;
	public bool tripleFire = false;

	public bool missiles = false;
	public bool mines = false;

	public bool shield = false;
	public bool ultraSound = false;
	public bool controlTweaks = false;
	public bool cannonAI = false;

	[Header("Equiped Upgrades")]

	public bool sFEquipped = true;
	public bool dFEquipped = false;
	public bool tFEquipped = false;

	public bool msEquipped = false;
	public bool mnEquipped = false;

	public bool sEquipped = false;
	public bool usEquipped = false;
	public bool cTEquipped = false;
	public bool AIEquipped = false;


}
