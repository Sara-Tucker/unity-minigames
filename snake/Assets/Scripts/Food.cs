using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gets called whenever another Collider collides with this object.
        // other is the reference for the object that collided with it.
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
