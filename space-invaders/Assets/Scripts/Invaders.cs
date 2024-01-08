using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public Projectile missilePrefab;
    public float missileAttackRate = 1.0f;
    public int amountKilled { get; private set; }
    public int amountAlive => totalInvaders - amountKilled;
    public int totalInvaders => rows * columns;
    public float percentKilled => (float)amountKilled / (float)totalInvaders;

    private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, centerOffset.y + (row * 2.0f), 0.0f);

            for (int column = 0; column < columns; column++)
            {
                Invader invader = Instantiate(prefabs[row], this.transform);
                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += column * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
    }

    private void Update()
    {
        this.transform.position += _direction * speed.Evaluate(percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // Loops through every child transform parented to this transform.
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;

            if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;

            if (Random.value < (1.0f / (float) amountAlive))
            {
                Instantiate(missilePrefab, invader.transform.position, Quaternion.identity);
                break;
            }
        }
    }

    private void InvaderKilled()
    {
        amountKilled++;

        if (amountKilled >= totalInvaders)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
