using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour 
{
	[Header("Thurster Objects")]
	public GameObject thrusterForward;
	public GameObject thrusterLeft;
	public GameObject thrusterRight;

	[Header("Ship movement settings")]
	[SerializeField]
	private float shipMovementForce = 0;
	private float currentMovementForce = 0;
	[SerializeField]
	private float forceStrength = 0;
	[SerializeField]
	private float forceSmoothing = 0;
	//[SerializeField]
	//private float speedBoostForce = 0;
	[SerializeField]
	private float shipRotSpeed = 0;
	
	private bool movementEnabled = true;
	
	private Vector3 currentMovement;
	Rigidbody rigidBody;

	#region properties

	public bool MovementEnabled {
		get 
		{
			return movementEnabled;
		}
		set
		{
			movementEnabled = value;
		}
	}

	#endregion

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
	}
	

	//Late Update since we are using rigidbodies for movement
	void LateUpdate()
	{
		if(movementEnabled)
		{
			//Move by adding force forward
			if(Input.GetButton("Forward"))
			{
				//Add a force on button press and hold, if the velocity magnitude is bigger than expected, set to maximum allowed
				rigidBody.AddForce(transform.up * shipMovementForce * forceStrength);

				thrusterForward.GetComponent<ParticleSystem>().Play();

				if(rigidBody.velocity.magnitude >= shipMovementForce)
				{
					rigidBody.velocity = rigidBody.velocity.normalized * shipMovementForce;
				}
			}
			else
			{
				//Slowly decrease the force of the ship to 0
				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity,Vector3.zero,Time.deltaTime * forceSmoothing);
				thrusterForward.GetComponent<ParticleSystem>().Stop();
			}

			//Rotate ship left
			if(Input.GetButton("RotLeft"))
			{
				transform.Rotate(Vector3.forward * Time.deltaTime * shipRotSpeed);
				thrusterLeft.GetComponent<ParticleSystem>().Play();
			}
			else
			{
				thrusterLeft.GetComponent<ParticleSystem>().Stop();
			}

			//Rotate ship right
			if(Input.GetButton("RotRight"))
			{
				transform.Rotate(Vector3.forward * Time.deltaTime * -shipRotSpeed);
				thrusterRight.GetComponent<ParticleSystem>().Play();
			}
			else
			{
				thrusterRight.GetComponent<ParticleSystem>().Stop();
			}

		}
	}
}
