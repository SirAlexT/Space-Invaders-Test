using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody2D _bullet;

	private void Start()
	{
		_bullet = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		_bullet.velocity = new Vector2(0, 10);

		if(!GetComponent<SpriteRenderer>().isVisible)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("BLUE"))
		{
			gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag("GREEN"))
		{
			gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag("RED"))
		{
			gameObject.SetActive(false);
		}
	}
}
