using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class start : MonoBehaviour
{
    // �x�����Ԃ�ݒ�i�b���j
    public float delayTime = 0.1f;

    public void StartGame()
    {
        // �R���[�`�����J�n
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // delayTime�b�҂�
        yield return new WaitForSeconds(delayTime);

        // �V�[�������[�h
        SceneManager.LoadScene("GameScene");
    }
}
