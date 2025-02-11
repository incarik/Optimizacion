using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int poolIndex = 2; // Índice del pool de enemigos en el PoolManager
    [SerializeField] private float spawnInterval = 2f; // Intervalo de aparición
    [SerializeField] private Vector3 spawnAreaMin; // Esquina mínima del área de spawn (por ejemplo, esquina inferior izquierda)
    [SerializeField] private Vector3 spawnAreaMax; // Esquina máxima del área de spawn (por ejemplo, esquina superior derecha)
    [SerializeField] private bool spawn = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawn)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Genera una posición aleatoria dentro del área definida
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        // Usamos el PoolManager para obtener un enemigo del pool
        GameObject Enemy = PoolManager.Instance.GetPooledObjects(poolIndex, randomPosition, Quaternion.Euler(0,180,0));

        if (Enemy != null)
        {
            Enemy.SetActive(true); // Activamos el enemigo una vez que lo obtenemos del pool
        }
        else
        {
            Debug.Log("Sin enemigos");
        }
    }
}
