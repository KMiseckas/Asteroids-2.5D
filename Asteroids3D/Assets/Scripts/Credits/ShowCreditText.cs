using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowCreditText : MonoBehaviour 
{

	private Text creditText;

	void Start()
	{
		creditText = GetComponent<Text>();
	}

	void Update()
	{
		creditText.text = "Credit: " + CreditData.currentCredit;
	}

}
