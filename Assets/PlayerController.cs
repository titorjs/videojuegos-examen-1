using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed;    // Velocidad de movimiento del jugador
    public float jumpForce;   // Fuerza de salto del jugador
    public int lives = 3;
    private Rigidbody rb;
    private bool isGrounded;
    private bool hasSecondJump;
    private Vector3 originalGravity;
    private Vector3 inicio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
        hasSecondJump = false;
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (transform.position.y <= -1)
        {
            //lives--;
            //if (lives == 0)
            //{
            //    transform.position = new Vector3(44f, 3.45f, 0f); ;
            //    lives = 3;
            //}
            Vector3 newPosition = new Vector3(transform.position.x + 5f, 3.5f, transform.position.z);
            rb.MovePosition(newPosition);
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                hasSecondJump = true;
            }else if(hasSecondJump)
            {
                rb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
                isGrounded = false;
                hasSecondJump = false;
            }
        }

        // Modificar la gravedad cuando el jugador no esté en el suelo
        if (!isGrounded)
        {
            Physics.gravity = originalGravity * 2f; // Duplicar la gravedad
        }
        else
        {
            Physics.gravity = originalGravity; // Restaurar la gravedad original
        }

        if(transform.position.x <= -180)
        {
            SceneManager.LoadScene("Fin");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasSecondJump = false;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            transform.position = new Vector3(44f, 3.45f, 0f);
            Debug.Log("bullet");
        }
    }
}
