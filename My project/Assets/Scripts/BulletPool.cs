using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
	public static BulletPool SharedInstace;

	public List<GameObject> _pooledBullets;

	public GameObject _bulletToPool;

	public int _amountToPool;

	private void Awake()
	{
		SharedInstace = this;
	}

	private void Start()
	{
		_pooledBullets = new List<GameObject>();
		GameObject tmp;

		for (int i = 0; i < _amountToPool; i++)
		{
			tmp = Instantiate(_bulletToPool);
			tmp.SetActive(false);
			_pooledBullets.Add(tmp);
		}
	}

	public GameObject GetPooledBUllet()
	{
		for (int i = 0; i < _amountToPool; i++)
		{
			if(!_pooledBullets[i].activeInHierarchy)
			{
				return _pooledBullets[i];
			}
		}
		return null;
	}
}
