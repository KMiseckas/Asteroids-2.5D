using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
	[Header("Shield Settings")]
	private int shieldCapacity = 100;
	[SerializeField]
	private int dmgToShieldOnHit = 0;
	[SerializeField]
	private float shieldNextRegen = 0;
	private float shieldRegenRate = 0.05f;
	private int shieldRegenAmount = 1;

	[Header("Condition Colors")]
	public Color healthyCapacityShield;
	public Color damagedCapacityShield;
	public Color criticalCapacityShield;

	[Header("Shield Object")]
	public GameObject shield;

	private bool shieldEnabled = true;

	public static int currentShieldCapacity;

	DisplayWeaponStats weapText;

	public bool ShieldEnabled 
	{
		get {return shieldEnabled;}
		set {shieldEnabled = value;}
	}

	void Start()
	{
		weapText = GetComponent<DisplayWeaponStats> ();
		weapText.DisplayUtility ("Shield: 100%");
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

		if(!shieldEnabled)
		{
			if(Time.time > shieldNextRegen)
			{
				shieldNextRegen = Time.time + shieldRegenRate;

				shieldCapacity += shieldRegenAmount;

				if(shieldCapacity >= 100)
				{
					shieldEnabled = true;
					shield.SetActive(true);
					shield.GetComponent<Renderer>().material.color = healthyCapacityShield;
					shield.GetComponent<ShieldTextureAnimation>().StartCoroutine("Start");
				}

				weapText.DisplayUtility("Shield: " + shieldCapacity.ToString() + "%");
			}
		}

		if(shieldCapacity <= 0)
		{
			shieldEnabled = false;
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

		weapText.DisplayUtility("Shield: " + shieldCapacity.ToString() + "%");

		//Debug.Log(currentShieldCapacity);
	}

}
