using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 15;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            collider.gameObject.SetActive(false); // Desactiva el enemigo
            return;
        }

        gameObject.SetActive(false); // Desactiva la bala después de la colisión
    }
}
