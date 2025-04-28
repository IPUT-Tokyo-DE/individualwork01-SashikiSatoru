using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rankText;

    void Start()
    {
        int score = GameManager.finalScore;

        scoreText.text = "Score: " + score.ToString();
        rankText.text = "Rank: " + GetRank(score);
    }

    string GetRank(int score)
    {
        if (score >= 40) // SSランクの順位を修正（40点以上）
            return "SS";
        else if (score >= 35)
            return "S";
        else if (score >= 25)
            return "A";
        else if (score >= 17)
            return "B";
        else if (score == 0)
            return "D";
        else
            return "C";
    }

    public void StartGame()
    {
        // コルーチンを開始
        StartCoroutine("GameScene");
    }

    public void OnRetryButton()
    {
        // リトライボタンが押された際にディレイ付きでシーン遷移
        StartCoroutine(LoadSceneWithDelay("GameScene"));
    }

    public void OnTitleButton()
    {
        // タイトルボタンが押された際にディレイ付きでシーン遷移
        StartCoroutine(LoadSceneWithDelay("TitleScene"));
    }

    // コルーチンでシーン遷移を遅らせる
    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // ここでディレイ時間を設定（例: 2秒）
        yield return new WaitForSeconds(0.5f);

        // シーンをロード
        SceneManager.LoadScene(sceneName);
    }
}

