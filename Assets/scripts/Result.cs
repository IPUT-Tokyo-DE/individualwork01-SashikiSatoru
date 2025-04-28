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
        if (score >= 40) // SS�����N�̏��ʂ��C���i40�_�ȏ�j
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
        // �R���[�`�����J�n
        StartCoroutine("GameScene");
    }

    public void OnRetryButton()
    {
        // ���g���C�{�^���������ꂽ�ۂɃf�B���C�t���ŃV�[���J��
        StartCoroutine(LoadSceneWithDelay("GameScene"));
    }

    public void OnTitleButton()
    {
        // �^�C�g���{�^���������ꂽ�ۂɃf�B���C�t���ŃV�[���J��
        StartCoroutine(LoadSceneWithDelay("TitleScene"));
    }

    // �R���[�`���ŃV�[���J�ڂ�x�点��
    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // �����Ńf�B���C���Ԃ�ݒ�i��: 2�b�j
        yield return new WaitForSeconds(0.5f);

        // �V�[�������[�h
        SceneManager.LoadScene(sceneName);
    }
}

