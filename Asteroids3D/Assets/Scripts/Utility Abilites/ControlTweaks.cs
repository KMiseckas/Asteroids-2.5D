using UnityEngine;
using System.Collections;

public class ControlTweaks : MonoBehaviour 
{

	Rigidbody rb;

	DisplayWeaponStats weapText;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		rb.mass = 0.4f;
		rb.drag = 1.5f;

		weapText = GetComponent<DisplayWeaponStats> ();
		weapText.DisplayUtility ("Control Tweaks");
	}

}
