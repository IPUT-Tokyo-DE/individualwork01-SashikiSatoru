using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 40f;
    private float timer;

    public TextMeshProUGUI timerText;

    private bool isGameOver = false;

    public static int finalScore = 0;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (isGameOver) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            GameOver();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        finalScore = ScoreManager.Instance.GetScore();
        SceneManager.LoadScene("ResultScene");
    }
}
