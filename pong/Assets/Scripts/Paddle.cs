using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10.0f;
    protected Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        m_rigidbody.position = new Vector2(m_rigidbody.position.x, 0.0f);
        m_rigidbody.velocity = Vector2.zero;
    }
}
