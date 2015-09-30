using UnityEngine;
using System.Collections;

public class ShipShooting : MonoBehaviour 
{
	private GameObject levelManager;

	private float fireRate = 0;
	private float nextFire = 0;
	private float nextFireMissile = 0;
	private float nextDeployMine = 0;

	private bool shootingEnabled = true;
	
	[Header("Bullet Gameobject")]
	public GameObject bullet;
	
	[Header("Missile Gameobject")]
	public GameObject missile;

	[Header("Mine Gameobject")]
	public GameObject mine;

	[Header("Bullet Parent")]
	public GameObject bulletParentObject;

	[Header("Muzzle/Launch Points")]
	public Transform forwardMuzzle;
	public Transform doubleLeftMuzzle;
	public Transform doubleRightMuzzle;
	public Transform tripleLeftMuzzle;
	public Transform tripleRightMuzzle;
	public Transform missileLauncher;

	[Header("Bullet Settings")] //Variables set in inspector
	[SerializeField] private float bulletForce = 0;
	[SerializeField] private float destroyBulletTime = 2.5f;
	[SerializeField] private float singleFireRate = 0;
	[SerializeField] private float doubleFireRate = 0;
	[SerializeField] private float tripleFireRate = 0;

	[Header("Missile Settings")] //Variables set in inspector
	[SerializeField] private int missileCount = 4;
	[SerializeField] private float missileForce = 0;
	[SerializeField] private float missileFireRate = 0.5f;
	//[SerializeField] private float missileSmoothness = 0;

	[Header("Mine Settings")] //Variables set in inspector
	[SerializeField] private int mineCount = 6;
	[SerializeField] private float mineDeployRate = 0.2f;

	[Header("Primary Weapon Type")] //Variables set in inspector
	[SerializeField] private string weaponType;

	[Header("Secondary Weapon Type")] //Variables set in inspector
	[SerializeField] private string secWeaponType;

	AssignToParent assignToParent;

	DisplayWeaponStats weapText;
	

	#region properties
	public bool ShootingEnabled 
	{
		get {return shootingEnabled;}
		set {shootingEnabled = value;}
	}

	public float SingleFireRate 
	{
		get {return singleFireRate;}
		set {singleFireRate = value;}
	}

	public float DoubleFireRate 
	{
		get {return doubleFireRate;}
		set {doubleFireRate = value;}
	}

	public float TripleFireRate 
	{
		get {return tripleFireRate;}
		set {tripleFireRate = value;}
	}

	public string SecWeaponType 
	{
		get {return secWeaponType;}
		set {secWeaponType = value;}
	}

	public string WeaponType 
	{
		get {return weaponType;}
		set {weaponType = value;}
	}

	#endregion

	void Awake()
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		assignToParent = levelManager.GetComponent<AssignToParent>();

		if(secWeaponType != null)
		{
			weapText = GetComponent<DisplayWeaponStats>();
			weapText.DisplaySpecial("Missiles: 10");

		}
	}

	void Update()
	{
		if(shootingEnabled)
		{
			//Primary weapon input
			if(Input.GetButton("Shoot"))
			{
				switch(weaponType)
				{
				case "Single_Fire":

					//change firerate
					fireRate = singleFireRate;

					if(Time.time > nextFire)
					{
						nextFire = Time.time + fireRate;

						//instantiate bullet and assign as gameobject
						GameObject newBullet = Instantiate(bullet,forwardMuzzle.position,transform.rotation) as GameObject;

						//Set parent of new bullets ( tidy the hierachy up runtime )
						assignToParent.AssignParent(newBullet,bulletParentObject);

						//apply force to bullet
						newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.up * bulletForce,ForceMode.Impulse);

						Destroy(newBullet,destroyBulletTime);
					}
					break;
				case "Double_Fire":

					//change firerate
					fireRate = doubleFireRate;

					if(Time.time > nextFire)
					{
						nextFire = Time.time + fireRate;

						//instantiate bullets, assign as gameobjects
						GameObject newBullet = Instantiate(bullet,doubleLeftMuzzle.position,transform.rotation) as GameObject;

						//Set parent of new bullets ( tidy the hierachy up runtime )
						assignToParent.AssignParent(newBullet,bulletParentObject);

						//apply force to bullets
						newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.up * bulletForce,ForceMode.Impulse);

						Destroy(newBullet,destroyBulletTime);

						StartCoroutine(FireSecondShot());

					}
				
					break;
				case "Triple_Fire":

					//change firerate
					fireRate = tripleFireRate;

					if(Time.time > nextFire)
					{
						nextFire = Time.time + fireRate;

						//Instantiate bullets and assign as gameobject
						GameObject newBullet = Instantiate(bullet,forwardMuzzle.position,transform.rotation) as GameObject;
						GameObject newBullet2 = Instantiate(bullet,tripleLeftMuzzle.position,transform.rotation) as GameObject;
						GameObject newBullet3 = Instantiate(bullet,tripleRightMuzzle.position,transform.rotation) as GameObject;

						//Set parent of new bullets ( tidy the hierachy up runtime )
						assignToParent.AssignParent(newBullet,bulletParentObject);
						assignToParent.AssignParent(newBullet2,bulletParentObject);
						assignToParent.AssignParent(newBullet3,bulletParentObject);

						//rotate 2 side bullets to give shotgun feeling
						newBullet2.transform.Rotate(Vector3.forward * 10);
						newBullet3.transform.Rotate(Vector3.forward * -10);

						//apply force to the bullets
						newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.up * bulletForce,ForceMode.Impulse);
						newBullet2.GetComponent<Rigidbody>().AddForce(newBullet2.transform.up * bulletForce,ForceMode.Impulse);
						newBullet3.GetComponent<Rigidbody>().AddForce(newBullet3.transform.up * bulletForce,ForceMode.Impulse);

						Destroy(newBullet,destroyBulletTime);
						Destroy(newBullet2,destroyBulletTime);
						Destroy(newBullet3,destroyBulletTime);
					}
					break;
				}



			}

			//Second weapon input
			if(Input.GetButton("Shoot_Secondary"))
			{
				switch(secWeaponType)
				{
				case "Missile":
					if(Time.time > nextFireMissile)
					{
						if(missileCount >= 1)
						{
							missileCount --;

							weapText.DisplaySpecial("Missiles: " + missileCount.ToString());

							nextFireMissile = Time.time + missileFireRate;

							//Instantiate missile on missile launcher position
							GameObject newMissile = Instantiate(missile,missileLauncher.position,new Quaternion(-90,0,0,transform.rotation.w)) as GameObject;

							Missile missileScript = newMissile.GetComponent<Missile>();
							missileScript.MissileForce = missileForce;
							//missileScript.MissileSmoothness = missileSmoothness;

							assignToParent.AssignParent(newMissile,bulletParentObject);
						}
						else
						{
							Debug.Log("No Missiles Left");
						}
					}
					break;
				case "Mine":
					
					break;
				case "Null":

					break;
				}
			}
		}
	}

	IEnumerator FireSecondShot()
	{
		yield return new WaitForSeconds(fireRate/2);

		GameObject newBullet2 = Instantiate(bullet,doubleRightMuzzle.position,transform.rotation) as GameObject;

		//Set parent of new bullets ( tidy the hierachy up runtime )
		assignToParent.AssignParent(newBullet2,bulletParentObject);

		newBullet2.GetComponent<Rigidbody>().AddForce(newBullet2.transform.up * bulletForce,ForceMode.Impulse);
			
		Destroy(newBullet2,destroyBulletTime);
	}

}
