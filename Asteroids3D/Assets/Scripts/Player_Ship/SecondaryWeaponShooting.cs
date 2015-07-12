using UnityEngine;
using System.Collections;

public class SecondaryWeaponShooting : MonoBehaviour 
{
	[Header("Launcher points")]
	public Transform missileLauncher;

	[Header("Missile Settings")]
	[SerializeField]
	private int missileCount = 4;
	[SerializeField]
	private int missileSpeed = 10;

	void Update()
	{

	}

}
