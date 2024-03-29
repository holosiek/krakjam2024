﻿using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : GameSystem
{
	[SerializeField]
	private float _maxObjects;
	
	private Queue<GameObject> _gameObjectsQueue = new Queue<GameObject>();

	public void AddGameObjectToQueue(GameObject gj)
	{
		_gameObjectsQueue.Enqueue(gj);

		if (_gameObjectsQueue.Count > _maxObjects)
		{
			var toDelete = _gameObjectsQueue.Dequeue();
			
			if (toDelete != null)
			{
				Destroy(toDelete);
			}
		}
	}
}
