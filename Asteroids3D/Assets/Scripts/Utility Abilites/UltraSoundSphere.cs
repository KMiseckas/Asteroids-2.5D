using UnityEngine;
using System.Collections;

public class UltraSoundSphere : MonoBehaviour 
{
	void FixedUpdate()
	{
		//Scale the object to look like a wave of sound expanding

		Vector3 scale = transform.localScale;

		float scaleLerp = Mathf.Lerp(scale.x,16,2.8f * Time.deltaTime);

		transform.localScale = new Vector3(scaleLerp,1,scaleLerp);

		if(scale.x > 10)
		{
			Destroy(gameObject);
		}
	}
}
