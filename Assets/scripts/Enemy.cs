using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private int _ammoType = 3;
    [SerializeField] private float speed = 3f; // Velocidad del enemigo
    private Transform player; // Referencia al jugador
    [SerializeField] private bool spawn = true;

    private void Start()
    {
        // Busca al primer objeto con el tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Player'.");
        }
        //StartCoroutine(SpawnBullets());
    }

    void OnEnable()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (spawn)
        {
            Shoot();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void Shoot()
    {
        GameObject EnemyBullet = PoolManager.Instance.GetPooledObjects(_ammoType, _bulletSpawn.position, _bulletSpawn.rotation);
        if (EnemyBullet != null)
        {
            EnemyBullet.SetActive(true);
        }
        else
        {
            Debug.Log("Pool es demasiado pequeño");
        }
    }
}
