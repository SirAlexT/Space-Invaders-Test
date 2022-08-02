using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	[SerializeField]
	private Enemy[] prefabs;

	[SerializeField]
	private int _rows = 5;

	[SerializeField]
	private int _colums = 10;

	[SerializeField]
	private float _speed = 1;

	private Vector3 _direction = Vector2.right;

	private void Awake()
	{
		//Normal Grid
		for (int row = 0; row < this._rows; row++)
		{
			float witdh = 0.5f * (this._colums -1);
			float height = 0.5f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + row * 0.5f, 0f);

			for (int col = 0; col < this._colums; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

				Vector3 position = _rowPosition;
				position.x += col * 0.5f;
				_enemy.transform.localPosition = position;
			}
		}

		/*for (int row = 0; row < 1; row++)
		{
			float witdh = 1f * (this._colums - 1);
			float height = 1f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + row * 1f, 0f);

			for (int col = 0; col < this._colums; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

				Vector3 position = _rowPosition;
				position.x += col * 1f;
				_enemy.transform.localPosition = position;
			}
		}

		for (int row = 0; row < 1; row++)
		{
			float witdh = 1f * (this._colums - 1);
			float height = 1f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x - 0.5f, _centering.y + 1 * 1f, 0f);

			for (int col = 0; col < 11; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

				Vector3 position = _rowPosition;
				position.x += col * 1f;
				_enemy.transform.localPosition = position;
			}
		}

		for (int row = 0; row < 1; row++)
		{
			float witdh = 1f * (this._colums - 1);
			float height = 1f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + 2 * 1f, 0f);

			for (int col = 0; col < 10; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

				Vector3 position = _rowPosition;
				position.x += col * 1f;
				_enemy.transform.localPosition = position;
			}
		}*/

		/*for (int row = 0; row < this._rows; row++)
		{
			float witdh = 0.5f * (this._colums -1);
			float height = 0.5f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + row * 0.5f, 0f);

			Vector3 _rowPosition_02 = new Vector3(_centering.x + 0.25f, _centering.y + row * 0.5f, 0f);

			for (int col = 0; col < this._colums; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

				if (row == 0 || row == 2 || row == 4)
				{
					Vector3 position = _rowPosition_02;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
				else
				{
					Vector3 position = _rowPosition;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
			}
		}*/

		//Brick Wall Grid
		/*for (int row = 0; row < this._rows; row++)
		{
			float witdh = 0.5f * (this._colums - 1);
			float height = 0.5f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + row * 0.5f, 0f);

			Vector3 _rowPosition_02 = new Vector3(_centering.x + 0.25f, _centering.y + row * 0.5f, 0f);

			if (row == 0 || row == 2 || row == 4)
			{
				for (int col = 0; col < this._colums; col++)
				{
					Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

					Vector3 position = _rowPosition_02;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
			}
			else
			{
				for (int col = 0; col < this._colums + 1; col++)
				{
					Enemy _enemy = Instantiate(this.prefabs[row], this.transform);

					Vector3 position = _rowPosition;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
			}
		}*/
	}

	private void Update()
	{
		this.transform.position += _direction * this._speed * Time.deltaTime;

		Vector3 _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector3 _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

		foreach(Transform enemy in this.transform)
		{
			if(!enemy.gameObject.activeInHierarchy)
			{
				continue;
			}

			if(_direction == Vector3.right && enemy.position.x >= _rightEdge.x - 0.25f)
			{
				AdvanceRow();
			}
			else if(_direction == Vector3.left && enemy.position.x <= _leftEdge.x + 0.25f)
			{
				AdvanceRow();
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
