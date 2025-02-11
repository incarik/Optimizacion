using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Este método se llama cuando otro collider entra en el área del trigger
    void OnTriggerEnter(Collider collider)
    {
        // Verificamos si el objeto que entra tiene el tag "Enemy"
        if (collider.CompareTag("Enemy"))
        {
            // Desactivamos el enemigo
            collider.gameObject.SetActive(false);
        }
    }
}
