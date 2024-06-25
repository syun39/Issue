using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject _scoreController;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // スコアコントローラクラスを探す
            var _scoreController = FindObjectOfType<ScoreController>();
            // スコアを1加算
            _scoreController.AddScore(1);
            Destroy(gameObject); //削除
        }
    }

    //回答例
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }*/
}
