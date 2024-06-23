using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] ScoreController _scoreController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ScoreControllerオブジェクトについてるScriptのメソッドを使用
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
