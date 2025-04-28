using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class start : MonoBehaviour
{
    // 遅延時間を設定（秒数）
    public float delayTime = 0.1f;

    public void StartGame()
    {
        // コルーチンを開始
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // delayTime秒待つ
        yield return new WaitForSeconds(delayTime);

        // シーンをロード
        SceneManager.LoadScene("GameScene");
    }
}
