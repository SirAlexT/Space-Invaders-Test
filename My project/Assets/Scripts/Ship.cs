using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _ship;

	[SerializeField]
	private GameObject _bullet;

	private Transform _shipTransform;

	[SerializeField]
	private GameObject _gameOverPanel;

	[SerializeField]
	private Camera _camera;

	[SerializeField]
	private ShipScore _shipScore;

	//New drag and drop test
	[Header("Drag and Drop Test")]
	private Vector2 touchPosition;
	private bool moveAllow = false;
	private float deltaX;
	private float deltaY;

	private bool _moveAllow = true;

	private void Awake()
	{
		if (!_camera)
		{
			_camera = Camera.main;
		}
	}

	private void Start()
	{
		_shipTransform = GetComponentInChildren<Transform>();
	}

	private void Update()
	{
		float _direction = Input.GetAxisRaw("Horizontal");

		if(_direction < 0 && _moveAllow)
		{
			_ship.velocity = new Vector2(-5, 0);
		}
		else if (_direction > 0 && _moveAllow)
		{
			_ship.velocity = new Vector2(5, 0);
		}
		else
		{
			_ship.velocity = new Vector2(0, 0);
		}

		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.touchCount == 1 && moveAllow)
		{
			GameObject bullet = BulletPool.SharedInstace.GetPooledBUllet();

			if(bullet != null)
			{
				bullet.transform.position = _shipTransform.position;
				bullet.SetActive(true);
			}
		}

		if(_shipScore._enemiesKilled == 55)
		{
			_moveAllow = false;
		}

		DragAndDrop();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("RED") || collision.gameObject.CompareTag("BLUE") || collision.gameObject.CompareTag("GREEN"))
		{
			_moveAllow = false;
			_gameOverPanel.SetActive(true);
		}
	}

	void DragAndDrop()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

			switch (touch.phase)
			{
				case TouchPhase.Began:
					if (GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(touchPosition))
					{
						deltaX = touchPosition.x - transform.position.x;
						deltaY = touchPosition.y - transform.position.y;

						moveAllow = true;

						Debug.Log("Que pasa");
					}
					break;

				case TouchPhase.Moved:
					if (GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(touchPosition) && moveAllow)
					{
						_ship.MovePosition(new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY));
					}
					break;

				case TouchPhase.Ended:
					moveAllow = false;
					break;
			}
		}
	}
}
