using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Llamado al inicio para comenzar a generar balas cada 3 segundos
    void Start()
    {
        InvokeRepeating("GenerateBullet", 0f, 3f); // Llama al m�todo "GenerateBullet" cada 3 segundos, comenzando inmediatamente.
    }

    // M�todo para generar una bala
    void GenerateBullet()
    {
        // Generar una posici�n aleatoria en el rango de altura deseado
        float randomY = Random.Range(2.5f, 5f);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        // Instanciar la bala en la posici�n generada
        Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
