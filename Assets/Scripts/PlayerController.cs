using UnityEngine;
using UnityEngine.Rendering;

public class LabPlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;

    [SerializeField]
    private float zBound = 6.0f;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player has collected a powerup");
        }
    }

}
