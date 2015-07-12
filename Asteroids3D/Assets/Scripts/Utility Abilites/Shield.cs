using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
	[Header("Shield Settings")]
	private int shieldCapacity = 100;
	[SerializeField]
	private int dmgToShieldOnHit = 0;
	[SerializeField]
	private int shieldRegenRateASec = 1;

	[Header("Condition Colors")]
	public Color healthyCapacityShield;
	public Color damagedCapacityShield;
	public Color criticalCapacityShield;

	[Header("Shield Object")]
	public GameObject shield;

	private bool shieldEnabled = true;

	public static int currentShieldCapacity;

	public bool ShieldEnabled {
		get {
			return shieldEnabled;
		}
		set {
			shieldEnabled = value;
		}
	}
	
	void Update()
	{

		currentShieldCapacity = shieldCapacity;

		if(shieldEnabled)
		{
			if(shieldCapacity > 0)
			{
				if(shield.activeSelf == false)
				{
					shield.SetActive(true);
				}
			}
		}

		if(shieldCapacity <= 0)
		{
			//shieldCapacity = Time.
		}

	}

	public void ShieldHit()
	{
		if(shieldEnabled)
		{
			shieldCapacity -= dmgToShieldOnHit;

			if(shieldCapacity <= 0)
			{
				shield.SetActive(false);
			}

			if(shieldCapacity > 75 && shieldCapacity <= 100)
			{
				shield.GetComponent<Renderer>().material.color = healthyCapacityShield;
			}
			else if(shieldCapacity > 30 && shieldCapacity <=75)
			{
				shield.GetComponent<Renderer>().material.color = damagedCapacityShield;
			}
			else if(shieldCapacity > 0 && shieldCapacity <= 30)
			{
				shield.GetComponent<Renderer>().material.color = criticalCapacityShield;
			}
		}
		else
		{
			shield.SetActive(false);
		}

		Debug.Log(currentShieldCapacity);
	}

}
