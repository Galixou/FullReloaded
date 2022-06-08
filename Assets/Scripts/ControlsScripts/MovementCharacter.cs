using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    private float speed = 2;
    private float JUMPPOWER = 4;

    private float originalHeight;

    public Transform respawnPoint;

    Rigidbody rb;
    CapsuleCollider col;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        originalHeight = col.height;
    }

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;

        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;

        transform.Translate(Horizontal, 0, Vertical);

        // Syst�me de saut
        if (isGrounded() && Input.GetButtonDown("Jump"))
            rb.AddForce(Vector3.up * JUMPPOWER, ForceMode.Impulse);

        // Syst�me d'accroupissement
        if (isGrounded() && Input.GetButtonDown("Crouch"))
            col.height = 0;
        else if(Input.GetButtonUp("Crouch"))
            col.height = originalHeight;

        // Syst�me de sprint
        if (isGrounded() && Input.GetButtonDown("Run"))
            speed += 5;
        else if (Input.GetButtonUp("Run"))
            speed -= 5;

        // Syst�me de r�apparition
        if (rb.position.y <= -10)
        {
            transform.position = respawnPoint.position;
            speed = 2;
        }
            

    }

    private bool isGrounded() { return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f); }
}
