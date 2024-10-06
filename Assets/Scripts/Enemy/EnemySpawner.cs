using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _multySpawnPoints;
    // [SerializeField] private Transform _spawnPoint;
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

            //* Randomly select an enemy prefab
        int enemyIndex = Random.Range(0, _enemyPrefab.Length);
        GameObject enemyToSpawn = _enemyPrefab[enemyIndex];

        //* Randomly select a spawn point
        int spawnPointIndex = Random.Range(0, _multySpawnPoints.Length);
        Transform spawnPoint = _multySpawnPoints[spawnPointIndex];

        //* Check if the spawn point is available
        if (IsSpawnPointAvailable(spawnPoint.position))
        {
            //* Spawn the enemy at the selected spawn point
            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            //* Optional: Handle the case where the spawn point is not available
            // Debug.Log("Spawn point is occupied, trying another one.");
            //* You can implement a retry mechanism here if desired
        }


            // int rand = Random.Range(0, _enemyPrefab.Length);
            // // Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);

            // GameObject _enemyToSpawn = _enemyPrefab[rand];
            // Instantiate(_enemyToSpawn, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private bool IsSpawnPointAvailable(Vector3 position)
    {
        //* For 2D games, use Physics2D.OverlapCircleAll
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);

        //* For 3D games, use Physics.OverlapSphere
        //* Collider[] colliders = Physics.OverlapSphere(position, 0.1f);

        return colliders.Length == 0; // True if no colliders are overlapping
    }
}
