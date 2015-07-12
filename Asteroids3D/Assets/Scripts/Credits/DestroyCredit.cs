using UnityEngine;
using System.Collections;

public class DestroyCredit : MonoBehaviour 
{
	[Header("Credit Desctruction Timer")]
	[SerializeField]
	private float timeDestroy = 0; //Set in inspector
	[SerializeField]
	private float timeStartFade = 0; //Set in inspector
	[SerializeField]
	private bool disableFade = true;

	void Update()
	{
		timeDestroy -= Time.smoothDeltaTime;

		if(!disableFade)
		{
			if(timeDestroy <= timeStartFade)
			{
				Color color = gameObject.GetComponent<Renderer>().material.color;
				float alpha = color.a;
				color.a = Mathf.Lerp(alpha,0,0.01f);
				gameObject.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,color.a);

				//Debug.Log("Color Fading");
			}
		}

		if(timeDestroy <= 0)
		{
			Destroy(gameObject);
		}
	}

}
