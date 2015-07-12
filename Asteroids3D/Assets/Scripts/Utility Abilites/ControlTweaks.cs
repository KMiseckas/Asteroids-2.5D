using UnityEngine;
using System.Collections;

public class ControlTweaks : MonoBehaviour 
{

	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		rb.mass = 0.4f;
		rb.drag = 1.5f;
	}

}
