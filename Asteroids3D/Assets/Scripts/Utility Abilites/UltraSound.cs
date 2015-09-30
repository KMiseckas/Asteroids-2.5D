using UnityEngine;
using System.Collections;

public class UltraSound : MonoBehaviour 
{
	public GameObject sphere;
	[Header("UltraSound Settings")]
	[SerializeField]
	private float ultraSoundCoolDownRate = 0;
	[SerializeField]
	private int waveAmount = 0;
	[SerializeField]
	private float waveRate = 0.1f;

	private int counter = 3;
	private int ultraSoundCoolDown = 100;
	private float nextCoolDownDecrease = 0;

	private bool ultraSoundEnabled = true;

	public static int currentCoolDown;

	DisplayWeaponStats weapText;

	public bool UltraSoundEnabled 
	{
		get {return ultraSoundEnabled;}
		set {ultraSoundEnabled = value;}
	}

	void Start()
	{
		counter = waveAmount;
		ultraSoundCoolDown = 100;

		weapText = GetComponent<DisplayWeaponStats> ();
		weapText.DisplayUtility ("Ultrasound: 100%");
	}

	void Update()
	{
		if(ultraSoundEnabled)
		{

			if(ultraSoundCoolDown < 100)
			{
				if(Time.time > nextCoolDownDecrease)
				{
					nextCoolDownDecrease = Time.time + ultraSoundCoolDownRate;
					ultraSoundCoolDown ++;
				}
			}

			//If ability off cooldown, is ready to be used
			if(ultraSoundCoolDown >= 100)
			{
				//On input recieve start ultrasound
				if(Input.GetButtonDown("Special"))
				{
					StartUltraSound();
					StartCoroutine(StartNewWave());

				}
			}

			currentCoolDown = ultraSoundCoolDown;
		}
		else
		{
			ultraSoundCoolDown = 50;
		}

		weapText.DisplayUtility ("Ultrasound: " + ultraSoundCoolDown.ToString () + "%");
	}
	
	void StartUltraSound()
	{
		//Instantiate ultrasound object
		GameObject expandingCollider = Instantiate(sphere,transform.position,Quaternion.Euler(90,0,0)) as GameObject;
		ultraSoundCoolDown = 0;
	}

	IEnumerator StartNewWave()
	{
		yield return new WaitForSeconds(waveRate);

		//Every "waveRate" time, start a new ultra sound wave until counter = 0
		if(counter > 0)
		{
			counter --;
			StartUltraSound();
			StartCoroutine(StartNewWave());
		}
		else
		{
			counter = waveAmount;
		}
	}
}
