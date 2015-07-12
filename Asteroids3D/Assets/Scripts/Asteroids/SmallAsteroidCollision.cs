using UnityEngine;
using System.Collections;

public class SmallAsteroidCollision : MonoBehaviour 
{
	[Header("Asteroid Hit Points")]
	[SerializeField]
	private int hitPoints = 1;

	[Header("Asteroid Destruction Score")]
	[SerializeField]
	private int scoreValue = 0;

	[Header("Asteroid Credit Drop Settings")]
	[SerializeField]
	private int creditDrop = 0;
	[SerializeField]
	private float coinForce = 0;
	public GameObject creditItem;

	private bool beenHit = false;

	private GameObject playerShip;

	RespawnShip destroyShip;

	void Awake()
	{
		playerShip = GameObject.FindGameObjectWithTag("Player");
	}

	//Check for collisions between objects
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player" && !beenHit)
		{
			beenHit = true;
			PlayerLives.playerLives --;
			destroyShip = playerShip.GetComponent<RespawnShip>();
			destroyShip.DisablePlayerShip();
			DestroyAsteroid();
		}
		
		if(col.gameObject.tag == "Bullet_Projectile" && !beenHit)
		{
			beenHit = true;
			hitPoints --;
			Destroy(col.gameObject);

			if(hitPoints == 0)
			{
				DestroyAsteroid();
			}
			else
			{
				beenHit = false;
			}
		}

		if(col.gameObject.tag == "UltraSound")
		{
			DestroyAsteroid();
		}

		if(col.gameObject.tag == "Shield")
		{
			col.gameObject.transform.parent.gameObject.GetComponent<Shield>().ShieldHit();
			
			DestroyAsteroid();
		}
	}

	public void DestroyAsteroid()
	{
		AddScore();
		SpawnCredits();
		Destroy();
	}

	void AddScore()
	{
		ScoreManager.score += scoreValue;
	}

	void Destroy()
	{
		Destroy(gameObject);
	}

	void SpawnCredits()
	{
		for(int i = 0; i < creditDrop; i++)
		{
			GameObject newCredit = Instantiate(creditItem,transform.position,Quaternion.Euler(0,0,0)) as GameObject;
			newCredit.transform.Rotate(Vector3.forward * Random.Range(-170,170));
			newCredit.GetComponent<Rigidbody>().AddForce(newCredit.transform.up * coinForce,ForceMode.Impulse);
			newCredit.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
		}
	}
	
}
