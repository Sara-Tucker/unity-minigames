using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 m_direction = Vector2.right;
    private List<Transform> m_segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;

    // Start is called before the first frame update
    private void Start()
    {
        ResetState();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = m_segments.Count - 1; i > 0; i--)
        {
            m_segments[i].position = m_segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x + m_direction.x),
            Mathf.Round(this.transform.position.y + m_direction.y));
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = m_segments[m_segments.Count - 1].position;

        m_segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < m_segments.Count; i++)
        {
            Destroy(m_segments[i].gameObject);
        }

        m_segments.Clear();
        m_segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            m_segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gets called whenever another Collider collides with this object.
        // other is the reference for the object that collided with it.
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
