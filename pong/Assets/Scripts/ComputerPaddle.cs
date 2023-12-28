using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0.0f)
        {
            if (ball.position.y > this.transform.position.y)
            {
                m_rigidbody.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < this.transform.position.y)
            {
                m_rigidbody.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if (this.transform.position.y > 0.0f)
            {
                m_rigidbody.AddForce(Vector2.down * speed);
            }
            else if (this.transform.position.y < 0.0f)
            {
                m_rigidbody.AddForce(Vector2.up * speed);
            }
        }
    }
}
