using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlueEnemy : MonoBehaviour
{
	private int _health = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bala"))
		{
			_health--;
		}
	}

	private void Update()
	{
		if (_health == 0)
		{
			GameObject.FindGameObjectWithTag("GamePoints").GetComponent<ShipScore>().BlueEnemyKilledScore(1);
			GameObject.FindGameObjectWithTag("GamePoints").GetComponent<ShipScore>().EnemiesDead();
			this.gameObject.SetActive(false);
		}
	}
}
