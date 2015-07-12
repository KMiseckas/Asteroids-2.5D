using UnityEngine;
using System.Collections;

public class ShieldTextureAnimation : MonoBehaviour 
{
	private float offset = 0;

	IEnumerator Start()
	{
		//Changes offset of texture on the y coordinate

		yield return new WaitForSeconds(0.05f);
		offset += 0.1f;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0,offset));

		if(offset == 1)
		{
			offset = 0;
		}

		StartCoroutine(Start ());
	}

}
