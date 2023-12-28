using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public TMPro.TMP_Text playerScoreText;
    public TMPro.TMP_Text computerScoreText;
    private int m_playerScore;
    private int m_computerScore;

    public void PlayerScores()
    {
        m_playerScore++;
        playerScoreText.text = m_playerScore.ToString();
        ResetRound();
    }

    public void ComputerScores()
    {
        m_computerScore++;
        computerScoreText.text = m_computerScore.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }
}
