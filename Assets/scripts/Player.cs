using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private int _ammoType = 0;
    [SerializeField] private float _moveSpeed = 5f; // Velocidad de movimiento

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z);
    }

    void Shoot()
    {
        GameObject bullet = PoolManager.Instance.GetPooledObjects(_ammoType, _bulletSpawn.position, _bulletSpawn.rotation);
        if (bullet != null)
        {
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("Pool es demasiado pequeño");
        }
    }
}
