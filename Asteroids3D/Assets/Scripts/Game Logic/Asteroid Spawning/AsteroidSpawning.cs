using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawning : MonoBehaviour 
{

	//Parent that will hold all asteroids when spawned
	private GameObject asteroidHolder;
	
	//Spawn Point Parent
	private GameObject asteroidSpawnPointParent;
	private GameObject asteroidParent;

	[Header("Asteroid Game Objects")]
	//Asteroid Types
	public GameObject lrgNormalAsteroid;
	public GameObject medNormalAsteroid;
	public GameObject smlNormalAsteroid;
	public GameObject lrgHeavyAsteroid;
	public GameObject medHeavyAsteroid;
	public GameObject smlHeavyAsteroid;
	public GameObject lrgIceAsteroid;
	public GameObject medIceAsteroid;
	public GameObject smlIceAsteroid;
	public GameObject lrgDiamondAsteroid;
	public GameObject medDiamondAsteroid;
	public GameObject smlDiamondAsteroid;

	[Header("Start Force of Asteroids")]
	[SerializeField] private float normalAsteroidLrg;
	[SerializeField] private float normalAsteroidMed;
	[SerializeField] private float normalAsteroidSml;
	[SerializeField] private float heavyAsteroidLrg;
	[SerializeField] private float heavyAsteroidMed;
	[SerializeField] private float heavyAsteroidSml;
	[SerializeField] private float iceAsteroidLrg;
	[SerializeField] private float iceAsteroidMed;
	[SerializeField] private float iceAsteroidSml;
	[SerializeField] private float diamondAsteroidLrg;
	[SerializeField] private float diamondAsteroidMed;
	[SerializeField] private float diamondAsteroidSml;

	List<Vector3> spawnPositions;

	AssignToParent assignToParent;

	void Awake()
	{
		spawnPositions = new List<Vector3>();
		asteroidSpawnPointParent = GameObject.FindGameObjectWithTag("SpawnPointParent");
		asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");

		assignToParent = GetComponent<AssignToParent>();

		//Add all the spawn points available to the list of spawn positions
		foreach (Transform spawnPoint in asteroidSpawnPointParent.transform)
		{
			Vector3 spawnPos = spawnPoint.transform.position;
			spawnPositions.Add(spawnPos);
		}
	}
	
	public void SpawnAsteroids(List<AsteroidsToSpawn> asteroidsToSpawn)
	{
		CheckReference();

		//check through each element and determine how many asteroids of what type will be spawned
		foreach(AsteroidsToSpawn element in asteroidsToSpawn)
		{
			switch(element.AsteroidType)
			{
			case "Normal_Large":
				SpawnNewAsteroid(lrgNormalAsteroid,element.AsteroidAmount,normalAsteroidLrg);
				break;
			case "Normal_Medium":
				SpawnNewAsteroid(medNormalAsteroid,element.AsteroidAmount,normalAsteroidMed);
				break;
			case "Normal_Small":
				SpawnNewAsteroid(smlNormalAsteroid,element.AsteroidAmount,normalAsteroidSml);
				break;
			case "Heavy_Large":
				SpawnNewAsteroid(lrgHeavyAsteroid,element.AsteroidAmount,heavyAsteroidLrg);
				break;
			case "Heavy_Medium":
				SpawnNewAsteroid(medNormalAsteroid,element.AsteroidAmount,heavyAsteroidMed);
				break;
			case "Heavy_Small":
				SpawnNewAsteroid(smlNormalAsteroid,element.AsteroidAmount,heavyAsteroidSml);
				break;
			case "Ice_Large":
				SpawnNewAsteroid(lrgIceAsteroid,element.AsteroidAmount,iceAsteroidLrg);
				break;
			case "Ice_Medium":
				SpawnNewAsteroid(medNormalAsteroid,element.AsteroidAmount,iceAsteroidMed);
				break;
			case "Ice_Small":
				SpawnNewAsteroid(smlNormalAsteroid,element.AsteroidAmount,iceAsteroidSml);
				break;
			case "Diamond_Large":
				SpawnNewAsteroid(lrgDiamondAsteroid,element.AsteroidAmount,diamondAsteroidLrg);
				break;
			case "Diamond_Medium":
				SpawnNewAsteroid(medNormalAsteroid,element.AsteroidAmount,diamondAsteroidMed);
				break;
			case "Diamond_Small":
				SpawnNewAsteroid(smlNormalAsteroid,element.AsteroidAmount,diamondAsteroidSml);
				break;
			}
		}
	}

	void SpawnNewAsteroid(GameObject asteroidType,int amount, float force)
	{
		//Spawns asteroids given
		for( int i = 1; i <= amount; i++)
		{
			int spawnPoint = Random.Range(0,spawnPositions.Count - 1);

			GameObject newAsteroid = Instantiate(asteroidType,spawnPositions[spawnPoint],Quaternion.Euler(0,0,0)) as GameObject;
			newAsteroid.transform.Rotate(Vector3.forward * Random.Range(-170,170));
			newAsteroid.GetComponent<Rigidbody>().AddForce(newAsteroid.transform.up * force,ForceMode.Impulse);
			newAsteroid.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));

			assignToParent.AssignParent(newAsteroid,asteroidParent);
		}
	}

	void CheckReference()
	{
		if(asteroidParent == null)
		{
			asteroidParent = GameObject.FindGameObjectWithTag("AsteroidParent");
			
			assignToParent = GetComponent<AssignToParent>();
		}
	}
}
