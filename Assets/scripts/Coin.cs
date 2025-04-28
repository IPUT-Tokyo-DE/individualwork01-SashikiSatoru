using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private CoinType coinType;

    void Start()
    {
        coinType = GetComponent<CoinType>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player p = other.GetComponent<player>();
            if (p != null && (int)p.currentShapeType == (int)coinType.requiredShape)
            {
                p.PlayCoinSound();
                ScoreManager.Instance.AddScore(1);
                Destroy(gameObject); 
            }
        }
    }

}
