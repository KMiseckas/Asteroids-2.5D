using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayWeaponStats : MonoBehaviour 
{

	public Text seconderyText;
	public Text utilityText;

	void Start()
	{
		seconderyText.text = "No Special";
		utilityText.text = "No Utility";
	}

	/// <summary>
	/// Displays the utility weapon stats	
	/// </summary>
	public void DisplayUtility(string text)
	{
		utilityText.text = text;
	}

	/// <summary>
	/// Displays the special weapon stats ( secondery weapons )
	/// </summary>
	public void DisplaySpecial(string text)
	{
		seconderyText.text = text;
	}

}
