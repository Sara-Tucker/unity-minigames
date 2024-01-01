using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private Rigidbody2D m_rigidBody;
    private bool m_thrusting;
    private float m_turnDirection;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_turnDirection = -1.0f;
        }
        else
        {
            m_turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (m_thrusting)
        {
            m_rigidBody.AddForce(this.transform.up * thrustSpeed);
        }

        if (m_turnDirection != 0)
        {
            m_rigidBody.AddTorque(m_turnDirection * turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

        bullet.Project(this.transform.up);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
