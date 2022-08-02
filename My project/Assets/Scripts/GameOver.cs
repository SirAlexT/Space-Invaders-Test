using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameOverPanel;

	[SerializeField]
	private Text _scoreText;

	[SerializeField]
	private ShipScore _shipScore;

	private void Awake()
	{
		_gameOverPanel.SetActive(false);
	}

	private void Update()
	{
		_scoreText.text = "Score: " + _shipScore._shipScore;
	}

	public void RetryLevel()
	{
		SceneManager.LoadScene("GameLevel");
	}

	public void TitleScreen()
	{
		SceneManager.LoadScene("TitleScene");
	}
}
