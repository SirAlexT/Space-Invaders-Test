using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
	private int splitScreen = Screen.height / 3;

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(Input.mousePosition.y >= 2 * splitScreen)
			{
				Debug.Log("Top");
			}

			if(Input.mousePosition.y >= splitScreen && Input.mousePosition.y < 2 * splitScreen)
			{
				Debug.Log("Middle");
			}

			if(Input.mousePosition.y < splitScreen)
			{
				Debug.Log("Down");
			}
		}
	}
}
