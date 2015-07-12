using UnityEngine;
using System.Collections;

public class MediumAsteroidCollision : MonoBehaviour 
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

	private GameObject levelManager;
	private GameObject asteroidParentObject;

	[Header("Asteroid To Spawn")]
	public GameObject smallAsteroid;

	private GameObject playership;

	RespawnShip destroyShip;

	#region properties

	public GameObject LevelManager {
		get {
			return levelManager;
		}
		set {
			levelManager = value;
		}
	}

	public GameObject AsteroidParentObject {
		get {
			return asteroidParentObject;
		}
		set {
			asteroidParentObject = value;
		}
	}
	#endregion

	private bool beenHit = false;

	//Used for applying the force to the newly spawned asteroids
	[Header("Break Off Force On Destruction")]
	[SerializeField]
	private float breakOffForce = 0;

	AssignToParent assignToParent;

	void Awake()
	{
		asteroidParentObject = GameObject.FindGameObjectWithTag("AsteroidParent");
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		playership = GameObject.FindGameObjectWithTag("Player");
		assignToParent = levelManager.GetComponent<AssignToParent>();
	}


	//Check for collisions between objects
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player" && !beenHit)
		{
			beenHit = true;
			PlayerLives.playerLives --;
			destroyShip = playership.GetComponent<RespawnShip>();
			destroyShip.DisablePlayerShip();
			SpawnNewAsteroid();
		}
		
		if(col.gameObject.tag == "Bullet_Projectile" && !beenHit)
		{
			beenHit = true;
			hitPoints --;
			col.gameObject.GetComponent<Collider>().enabled = false;
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
		SpawnNewAsteroid();
	}

	void AddScore()
	{
		ScoreManager.score += scoreValue;
	}
	
	void SpawnNewAsteroid()
	{
		for(int i = 0; i < 2; i++)
		{
			GameObject newSmallAsteroid = Instantiate(smallAsteroid,transform.position,Quaternion.Euler(0,0,0)) as GameObject;
			newSmallAsteroid.transform.Rotate(Vector3.forward * Random.Range(-90,90));
			newSmallAsteroid.GetComponent<Rigidbody>().AddForce(newSmallAsteroid.transform.up * breakOffForce,ForceMode.Impulse);
			newSmallAsteroid.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));

			assignToParent.AssignParent(newSmallAsteroid,asteroidParentObject);

		}
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
