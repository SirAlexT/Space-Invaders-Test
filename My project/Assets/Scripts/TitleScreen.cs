using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
	private void GoToSelectorScreen()
	{
		if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButton(0))
		{
			SceneManager.LoadScene("SelectorScreen");
		}
	}

	private void Update()
	{
		GoToSelectorScreen();
	}
}
