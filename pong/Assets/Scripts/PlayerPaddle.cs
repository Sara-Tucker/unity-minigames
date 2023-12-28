using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 m_direction;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_direction = Vector2.down;
        }
        else
        {
            m_direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (m_direction.sqrMagnitude != 0)
        {
            m_rigidbody.AddForce(m_direction * speed);
        }
    }
}
