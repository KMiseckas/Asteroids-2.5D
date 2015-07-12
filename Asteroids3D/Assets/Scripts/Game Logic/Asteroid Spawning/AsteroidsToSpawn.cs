using UnityEngine;
using System.Collections;

public class AsteroidsToSpawn : MonoBehaviour 
{

	private string asteroidType;
	private int asteroidAmount;

	#region properties
	public string AsteroidType {
		get {
			return asteroidType;
		}
		set {
			asteroidType = value;
		}
	}

	public int AsteroidAmount {
		get {
			return asteroidAmount;
		}
		set {
			asteroidAmount = value;
		}
	}
	#endregion

	public AsteroidsToSpawn(string type,int amount)
	{
		asteroidType = type;
		asteroidAmount = amount;

		//can add other asteroid features later if any are needed 

	}
}
