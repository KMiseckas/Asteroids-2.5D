using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoughtItemsCheck : MonoBehaviour
{

	ShipUpgrades shipUpgrades;
	CreditData credits;
	Attachments attachments;

	[Header("Buyables")]
	public Text singleFireDesc;
	public Text doubleFireDesc;
	public Text doubleFirePrice;
	public Text tripleFireDesc;
	public Text tripleFirePrice;
	public Text missilesDesc;
	public Text missilePrice;
	public Text minesDesc;
	public Text minesPrice;
	public Text ultrasoundDesc;
	public Text ultrasoundPrice;
	public Text shieldDesc;
	public Text shieldPrice;
	public Text controlsDesc;
	public Text controlPrice;
	public Text aiCannonDesc;
	public Text aiCannonPrice;

	[Header("Colors")]
	public Color boughtColor;
	public Color notBoughtColor;
	public Color selectedColor;

	[Header("Item Prices")]
	public int doubleFire;
	public int tripleFire;
	public int missiles;
	public int mines;
	public int ultrasound;
	public int shield;
	public int controls;
	public int aiCannon;

	void Start()
	{
		GameObject manager = GameObject.FindGameObjectWithTag ("LevelManager");
		shipUpgrades = manager.GetComponent<ShipUpgrades> ();
		credits = manager.GetComponent<CreditData> ();
		attachments = manager.GetComponent<Attachments> ();
		CheckStates ();
	}

	void CheckStates()
	{
		if(shipUpgrades.singleFire)
		{
			if(shipUpgrades.sFEquipped)
			{
				singleFireDesc.color = selectedColor;
			}
			else
			{
				singleFireDesc.color = boughtColor;
			}
		}

		if(shipUpgrades.doubleFire)
		{
			doubleFirePrice.text = "-";

			if(shipUpgrades.dFEquipped)
			{
				doubleFireDesc.color = selectedColor;
			}
			else
			{
				doubleFireDesc.color = boughtColor;
			}
		}
		else
		{
			doubleFireDesc.color = notBoughtColor;
			doubleFirePrice.text = "Price: " + doubleFire + "c";
		}

		if(shipUpgrades.tripleFire)
		{

			tripleFirePrice.text = "-";

			if(shipUpgrades.tFEquipped)
			{
				tripleFireDesc.color = selectedColor;
			}
			else
			{
				tripleFireDesc.color = boughtColor;
			}
		}
		else
		{
			tripleFireDesc.color = notBoughtColor;
			tripleFirePrice.text = "Price: " + tripleFire + "c";
		}

		if(shipUpgrades.missiles)
		{
			missilePrice.text = "-";

			if(shipUpgrades.msEquipped)
			{
				missilesDesc.color = selectedColor;
			}
			else
			{
				missilesDesc.color = boughtColor;
			}
		}
		else
		{
			missilesDesc.color = notBoughtColor;
			missilePrice.text = "Price: " + missiles + "C";
		}

		if(shipUpgrades.mines)
		{
			minesPrice.text = "-";

			if(shipUpgrades.mnEquipped)
			{
				minesDesc.color = selectedColor;
			}
			else
			{
				minesDesc.color = boughtColor;	
			}
		}
		else
		{
			minesDesc.color = notBoughtColor;
			minesPrice.text = "Price: " + mines + "c";
		}

		if(shipUpgrades.shield)
		{
			shieldPrice.text = "-";

			if(shipUpgrades.sEquipped)
			{
				shieldDesc.color = selectedColor;
			}
			else
			{
				shieldDesc.color = boughtColor;
			}
		}
		else
		{
			shieldDesc.color = notBoughtColor;
			shieldPrice.text = "Price: " + shield + "c";
		}

		if(shipUpgrades.ultraSound)
		{
			ultrasoundPrice.text = "-";

			if(shipUpgrades.usEquipped)
			{
				ultrasoundDesc.color = selectedColor;
			}
			else
			{
				ultrasoundDesc.color = boughtColor;
			}
		}
		else
		{
			ultrasoundDesc.color = notBoughtColor;
			ultrasoundPrice.text = "Price: " + ultrasound + "c";
		}

		if(shipUpgrades.controlTweaks)
		{
			controlPrice.text = "-";

			if(shipUpgrades.cTEquipped)
			{
				controlsDesc.color = selectedColor;
			}
			else
			{
				controlsDesc.color = boughtColor;
			}
		}
		else
		{
			controlsDesc.color = notBoughtColor;
			controlPrice.text = "Price: " + controls + "c";
		}

		if(shipUpgrades.cannonAI)
		{
			aiCannonPrice.text = "-";

			if(shipUpgrades.AIEquipped)
			{
				aiCannonDesc.color = selectedColor;
			}
			else
			{
				aiCannonDesc.color = boughtColor;
			}
		}
		else
		{
			aiCannonDesc.color = notBoughtColor;
			aiCannonPrice.text = "Price: " + aiCannon + "c";
		}
	}

	public void UseItem(string itemName)
	{
		switch(itemName)
		{
		case "singleFire":
			if(!shipUpgrades.sFEquipped)
			{
				shipUpgrades.sFEquipped = true;
				shipUpgrades.dFEquipped = false;
				shipUpgrades.tFEquipped = false;

				singleFireDesc.color = selectedColor;
				doubleFireDesc.color = boughtColor;
				tripleFireDesc.color = boughtColor;

				attachments.SetPrimaryWeapon("Single_Fire");
			}
			break;
		case "doubleFire":
			if(shipUpgrades.doubleFire)
			{
				if(!shipUpgrades.dFEquipped)
				{
					shipUpgrades.dFEquipped = true;
					shipUpgrades.sFEquipped = false;
					shipUpgrades.tFEquipped = false;
					
					singleFireDesc.color = boughtColor;
					doubleFireDesc.color = selectedColor;

					if(shipUpgrades.tripleFire)
					{
						tripleFireDesc.color = boughtColor;
					}
					
					attachments.SetPrimaryWeapon("Double_Fire");
				}
			}
			else
			{
				if(CreditData.currentCredit >= doubleFire)
				{
					shipUpgrades.doubleFire = true;
					CreditData.currentCredit -= doubleFire;
					doubleFirePrice.text = "-";
					doubleFireDesc.color = boughtColor;
				}
			}

			break;
		case "tripleFire":
			if(shipUpgrades.tripleFire)
			{
				if(!shipUpgrades.tFEquipped)
				{
					shipUpgrades.tFEquipped = true;
					shipUpgrades.sFEquipped = false;
					shipUpgrades.dFEquipped = false;
					
					singleFireDesc.color = boughtColor;

					if(shipUpgrades.doubleFire)
					{
						doubleFireDesc.color = boughtColor;
					}

					tripleFireDesc.color = selectedColor;
					
					attachments.SetPrimaryWeapon("Triple_Fire");
				}
			}
			else
			{
				if(CreditData.currentCredit >= tripleFire)
				{
					shipUpgrades.tripleFire = true;
					CreditData.currentCredit -= tripleFire;
					tripleFirePrice.text = "-";
					tripleFireDesc.color = boughtColor;
				}
			}
			break;
		case "missiles":
			if(shipUpgrades.missiles)
			{
				if(!shipUpgrades.msEquipped)
				{
					shipUpgrades.msEquipped = true;
					shipUpgrades.mnEquipped = false;
					
					missilesDesc.color = selectedColor;

					if(shipUpgrades.mines)
					{
						minesDesc.color = boughtColor;
					}
					
					attachments.SetSeconderyWeapon("Missile");
				}
			}
			else
			{
				if(CreditData.currentCredit >= missiles)
				{
					shipUpgrades.missiles = true;
					CreditData.currentCredit -= missiles;
					missilePrice.text = "-";
					missilesDesc.color = boughtColor;
				}
			}
			break;
		case "mines":
			if(shipUpgrades.mines)
			{
				if(!shipUpgrades.mnEquipped)
				{
					shipUpgrades.mnEquipped = true;
					shipUpgrades.msEquipped = false;

					minesDesc.color = selectedColor;

					if(shipUpgrades.missiles)
					{
						missilesDesc.color = boughtColor;
					}
					
					attachments.SetSeconderyWeapon("Mine");
				}
			}
			else
			{
				if(CreditData.currentCredit >= mines)
				{
					shipUpgrades.mines = true;
					CreditData.currentCredit -= mines;
					minesPrice.text = "-";
					minesDesc.color = boughtColor;
				}
			}
			break;
		case "shield":
			if(shipUpgrades.shield)
			{
				if(!shipUpgrades.sEquipped)
				{
					shipUpgrades.sEquipped = true;
					shipUpgrades.usEquipped = false;
					shipUpgrades.AIEquipped = false;
					shipUpgrades.cTEquipped = false;
					
					shieldDesc.color = selectedColor;

					if(shipUpgrades.cannonAI)
					{
						aiCannonDesc.color = boughtColor;
					}

					if(shipUpgrades.controlTweaks)
					{
						controlsDesc.color = boughtColor;
					}

					if(shipUpgrades.ultraSound)
					{
						ultrasoundDesc.color = boughtColor;
					}
					
					attachments.SetSpecialAbility("Shield");
				}
			}
			else
			{
				if(CreditData.currentCredit >= shield)
				{
					shipUpgrades.shield = true;
					CreditData.currentCredit -= shield;
					shieldPrice.text = "-";
					shieldDesc.color = boughtColor;
				}
			}
			break;
		case "ultrasound":
			if(shipUpgrades.ultraSound)
			{
				if(!shipUpgrades.usEquipped)
				{
					shipUpgrades.usEquipped = true;
					shipUpgrades.sEquipped = false;
					shipUpgrades.AIEquipped = false;
					shipUpgrades.cTEquipped = false;
					
					ultrasoundDesc.color = selectedColor;
					
					if(shipUpgrades.cannonAI)
					{
						aiCannonDesc.color = boughtColor;
					}
					
					if(shipUpgrades.controlTweaks)
					{
						controlsDesc.color = boughtColor;
					}
					
					if(shipUpgrades.shield)
					{
						shieldDesc.color = boughtColor;
					}
					
					attachments.SetSpecialAbility("UltraSound");
				}
			}
			else
			{
				if(CreditData.currentCredit >= ultrasound)
				{
					shipUpgrades.ultraSound = true;
					CreditData.currentCredit -= ultrasound;
					ultrasoundPrice.text = "-";
					ultrasoundDesc.color = boughtColor;
				}
			}
			break;
		case "aiCannon":
			if(shipUpgrades.cannonAI)
			{
				if(!shipUpgrades.AIEquipped)
				{
					shipUpgrades.AIEquipped = true;
					shipUpgrades.usEquipped = false;
					shipUpgrades.sEquipped = false;
					shipUpgrades.cTEquipped = false;
					
					aiCannonDesc.color = selectedColor;
					
					if(shipUpgrades.shield)
					{
						shieldDesc.color = boughtColor;
					}
					
					if(shipUpgrades.controlTweaks)
					{
						controlsDesc.color = boughtColor;
					}
					
					if(shipUpgrades.ultraSound)
					{
						ultrasoundDesc.color = boughtColor;
					}
					
					attachments.SetSpecialAbility("AICannon");
				}
			}
			else
			{
				if(CreditData.currentCredit >= aiCannon)
				{
					shipUpgrades.cannonAI = true;
					CreditData.currentCredit -= aiCannon;
					aiCannonPrice.text = "-";
					aiCannonDesc.color = boughtColor;
				}
			}
			break;
		case "controls":
			if(shipUpgrades.controlTweaks)
			{
				if(!shipUpgrades.cTEquipped)
				{
					shipUpgrades.cTEquipped = true;
					shipUpgrades.usEquipped = false;
					shipUpgrades.AIEquipped = false;
					shipUpgrades.sEquipped = false;
					
					controlsDesc.color = selectedColor;
					
					if(shipUpgrades.cannonAI)
					{
						aiCannonDesc.color = boughtColor;
					}
					
					if(shipUpgrades.shield)
					{
						shieldDesc.color = boughtColor;
					}
					
					if(shipUpgrades.ultraSound)
					{
						ultrasoundDesc.color = boughtColor;
					}
					
					attachments.SetSpecialAbility("ControlTweaks");
				}
			}
			else
			{
				if(CreditData.currentCredit >= controls)
				{
					shipUpgrades.controlTweaks = true;
					CreditData.currentCredit -= controls;
					controlPrice.text = "-";
					controlsDesc.color = boughtColor;
				}
			}
			break;
		}
	}


}
