using UnityEngine;
using System.Collections;

public class RespawnShip : MonoBehaviour 
{
	ShipShooting shootingScript;
	PlayerShipMovement movementScript;
	AICannon aiCannon;
	UltraSound ultraSound;

	[SerializeField]
	private float spawnBlinkAmount;
	[SerializeField]
	private float blinkShowTime;
	[SerializeField]
	private float blinkHideTime;

	void Awake()
	{
		shootingScript = GetComponent<ShipShooting>();
		movementScript = GetComponent<PlayerShipMovement>();
		aiCannon = GetComponent<AICannon>();
		ultraSound = GetComponent<UltraSound>();
	}

	public void DisablePlayerShip()
	{
		//Start Explosion
		//--------------------------

		//SHOOTING
		shootingScript.ShootingEnabled = false;
		movementScript.MovementEnabled  = false;

		//UTILITY ABILITIES
		aiCannon.EnableAI = false;
		ultraSound.UltraSoundEnabled = false;

		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Collider>().enabled = false;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		// + Other neccessary components to disable

		if(PlayerLives.playerLives >= 0)
		{
			StartCoroutine(ReSpawnShip());
		}
	}

	IEnumerator ReSpawnShip()
	{
		transform.position = new Vector3(0,0,0);
		transform.rotation = new Quaternion(0,0,0,transform.rotation.w);

		//Blink effect
		for(int i = 0; i < spawnBlinkAmount; i++)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
			yield return new WaitForSeconds(blinkHideTime);
			gameObject.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds(blinkShowTime);

			if(i == 0)
			{
				shootingScript.ShootingEnabled = true;
				movementScript.MovementEnabled = true;

				aiCannon.EnableAI = true;
				ultraSound.UltraSoundEnabled = true;
			}
		}

		//Return collider to gameobject
		gameObject.GetComponent<Collider>().enabled = true;
	}


}
