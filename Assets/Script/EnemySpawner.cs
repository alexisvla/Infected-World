using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemyPrefabs; 
	public float spawnInterval = 2f;  
	public Vector2 spawnAreaMin;      
	public Vector2 spawnAreaMax;      

	private float timeSinceLastSpawn;

	void Start()
	{
		timeSinceLastSpawn = 0f;
	}

	void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnInterval)
		{
			SpawnEnemy();
			timeSinceLastSpawn = 0f;
		}
	}

	void SpawnEnemy()
	{
		GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

		Vector2 spawnPosition = new Vector2(
			Random.Range(spawnAreaMin.x, spawnAreaMax.x),
			Random.Range(spawnAreaMin.y, spawnAreaMax.y)
		);

		Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
	}
}
