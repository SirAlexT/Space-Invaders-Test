using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipScore : MonoBehaviour
{
	[SerializeField]
	private Text _scoreText;

	[SerializeField]
	private GameConfiguration _gameConfig;

	[SerializeField]
	private GameObject _gameOverPanel;

	public int _shipScore;

	public int _enemiesKilled;

	private void Awake()
	{
		_shipScore = 0;
		_enemiesKilled = 0;
	}

	public void BlueEnemyKilledScore(int _points)
	{
		if(_gameConfig.transform.position.y > 1)
		{
			_shipScore = _shipScore + _points * 3;
		}

		if (_gameConfig.transform.position.y > -1 && _gameConfig.transform.position.y <= 1)
		{
			_shipScore = _shipScore + (_points * 2);
		}

		if (_gameConfig.transform.position.y <= -1)
		{
			_shipScore = _shipScore + _points;
		}
	}

	public void EnemiesDead()
	{
		_enemiesKilled++;
	}

	private void Update()
	{
		_scoreText.text = _shipScore.ToString();

		if(_enemiesKilled == 55)
		{
			_gameOverPanel.SetActive(true);
		}
	}
}
