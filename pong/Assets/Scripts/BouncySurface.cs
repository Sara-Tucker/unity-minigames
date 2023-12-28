using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null )
        {
            // This implementation isn't perfect. The Vector2 x value slows over time instead of increases.
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * bounceStrength);
        }
    }
}
