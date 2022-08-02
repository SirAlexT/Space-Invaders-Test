using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
	private int _health = 3;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bala"))
		{
			_health--;
		}
	}

	private void Update()
	{
		if(_health == 0)
		{
			GameObject.FindGameObjectWithTag("GamePoints").GetComponent<ShipScore>().BlueEnemyKilledScore(3);
			GameObject.FindGameObjectWithTag("GamePoints").GetComponent<ShipScore>().EnemiesDead();
			this.gameObject.SetActive(false);
		}
	}
}
