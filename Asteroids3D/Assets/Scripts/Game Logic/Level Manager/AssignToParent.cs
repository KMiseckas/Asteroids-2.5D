using UnityEngine;
using System.Collections;

public class AssignToParent : MonoBehaviour 
{

	public void AssignParent(GameObject child,GameObject parent)
	{
		child.transform.parent = parent.transform;
	}

}
