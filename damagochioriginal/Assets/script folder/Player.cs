using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public int score = 0;
    public Text scoreText;
    public GameObject heartPrefab;
    private int heartsRemaining = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText not found! Make sure the UI Text component is named 'ScoreText'.");
        }

        UpdateScoreText();
        SpawnHearts();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector2.left);
        }
        else
        {
            Move(Vector2.zero);
        }
    }

    void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gem")
        {
            score += 3;
            UpdateScoreText();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "enemy")
        {
            // Enemy와 충돌한 경우 해당 Enemy 파괴
            Destroy(collision.gameObject);

            // 목숨 감소
            heartsRemaining--;
            UpdateHearts();

            // 목숨이 0이면 게임 종료
            if (heartsRemaining <= 0)
            {
                GameOver();
            }
        }

        if (score >= 30)
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("Score updated: " + score);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
        Time.timeScale = 0f;
        // 게임 종료 처리를 추가
    }

    void SpawnHearts()
    {
        for (int i = 0; i < heartsRemaining; i++)
        {
            Instantiate(heartPrefab, new Vector3(-5f + i * 1.5f, 4f, 0f), Quaternion.identity);
        }
    }

    void UpdateHearts()
    {
        Destroy(GameObject.FindGameObjectWithTag("heart"));
        SpawnHearts();
    }
}
