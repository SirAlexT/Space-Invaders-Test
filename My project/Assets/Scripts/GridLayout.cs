using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grid Layout", menuName = "Level Grid Configuration")]
public class GridLayout : ScriptableObject
{
	[SerializeField]
	private Enemy[] prefabs;

	[SerializeField]
	private int _rows = 5;

	[SerializeField]
	private int _colums = 11;

	[SerializeField]
	private Transform _gridTransform;


	public void NormalGridLayout()
	{
		for (int row = 0; row < this._rows; row++)
		{
			float witdh = 0.5f * (this._colums - 1);
			float height = 0.5f * (this._rows - 1);

			Vector3 _centering = new Vector3(-witdh / 2, -height / 2);

			Vector3 _rowPosition = new Vector3(_centering.x, _centering.y + row * 0.5f, 0f);

			for (int col = 0; col < this._colums; col++)
			{
				Enemy _enemy = Instantiate(this.prefabs[row], GameObject.FindGameObjectWithTag("GridCreator").GetComponent<Transform>());

				Vector3 position = _rowPosition;
				position.x += col * 0.5f;
				_enemy.transform.localPosition = position;
			}
		}
	}

	public void BrickWallGridLayout()
	{
		for (int row = 0; row < this._rows; row++)
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
					Enemy _enemy = Instantiate(this.prefabs[row], GameObject.FindGameObjectWithTag("GridCreator").GetComponent<Transform>());

					Vector3 position = _rowPosition_02;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
			}
			else
			{
				for (int col = 0; col < this._colums + 1; col++)
				{
					Enemy _enemy = Instantiate(this.prefabs[row], GameObject.FindGameObjectWithTag("GridCreator").GetComponent<Transform>());

					Vector3 position = _rowPosition;
					position.x += col * 0.5f;
					_enemy.transform.localPosition = position;
				}
			}
		}
	}
}
