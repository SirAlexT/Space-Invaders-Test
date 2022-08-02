using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
	[SerializeField]
	private LevelSelection _levelSelector;

	public void GoToCreditsScene()
	{
		SceneManager.LoadScene("CreditsScene");
	}

	public void GoBackToSelectorScreen()
	{
		SceneManager.LoadScene("SelectorScreen");
	}

	public void SelectLevel01()
	{
		_levelSelector.LevelSelector01();
		SceneManager.LoadScene("GameLevel");
	}

	public void SelectLevel02()
	{
		_levelSelector.LevelSelector02();
		SceneManager.LoadScene("GameLevel");
	}
}
