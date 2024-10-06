using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_isSpawning)
        {
            int rand = Random.Range(0, _enemyPrefab.Length);
            // Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);

            GameObject _enemyToSpawn = _enemyPrefab[rand];
            Instantiate(_enemyToSpawn, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
