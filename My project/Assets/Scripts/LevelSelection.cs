using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Selection", menuName = "Level Selection Configuration")]
public class LevelSelection : ScriptableObject
{
	public int _levelSelector = 0;

	public void LevelSelector01()
	{
		_levelSelector = 1;
	}

	public void LevelSelector02()
	{
		_levelSelector = 2;
	}
}
