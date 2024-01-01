using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifetime = 10.0f;
    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void Project(Vector2 direction)
    {
        m_rigidbody.AddForce(direction * speed);

        Destroy(this.gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
