using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
	[SerializeField]
	private GridLayout _gridLayout;

	[SerializeField]
	private LevelSelection _levelSelection;

	[SerializeField]
	private float _speed = 1;

	[SerializeField]
	private Transform _shipTransform;

	private Vector3 _direction = Vector2.right;

	private void Awake()
	{
		if(_levelSelection._levelSelector == 1)
		{
			_gridLayout.NormalGridLayout();
		}

		if(_levelSelection._levelSelector == 2)
		{
			_gridLayout.BrickWallGridLayout();
		}
	}

	private void Update()
	{
		this.transform.position += _direction * this._speed * Time.deltaTime;

		Vector3 _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector3 _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

		foreach (Transform enemy in this.transform)
		{
			if (!enemy.gameObject.activeInHierarchy)
			{
				continue;
			}

			if (_direction == Vector3.right && enemy.position.x >= _rightEdge.x - 0.25f)
			{
				AdvanceRow();
			}
			else if (_direction == Vector3.left && enemy.position.x <= _leftEdge.x + 0.25f)
			{
				AdvanceRow();
			}

			if(enemy.position.y == _shipTransform.position.y)
			{
				_direction = Vector2.zero;
			}
		}
	}

	private void AdvanceRow()
	{
		_direction.x *= -1.0f;

		Vector3 position = this.transform.position;
		position.y -= 0.25f;
		this.transform.position = position;
	}
}
