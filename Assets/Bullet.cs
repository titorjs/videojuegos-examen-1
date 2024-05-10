using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Velocidad de la bala

    void Update()
    {
        // Mover la bala hacia la izquierda
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destruir la bala cuando llegue a x = 50
        if (transform.position.x >= 40f)
        {
            Destroy(gameObject);
        }
    }
}
