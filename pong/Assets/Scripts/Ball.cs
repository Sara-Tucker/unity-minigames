using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, 0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        m_rigidbody.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        m_rigidbody.AddForce(force);
    }

    public void ResetPosition()
    {
        m_rigidbody.position = Vector2.zero;
        m_rigidbody.velocity = Vector2.zero;
    }
}
