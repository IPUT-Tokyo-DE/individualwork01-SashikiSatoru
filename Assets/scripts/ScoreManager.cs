using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText; 
    private int score = 0;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreText(); 
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score; 
    }
}
