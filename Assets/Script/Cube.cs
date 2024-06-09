using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject _scoreController;

    private void Start()
    {
        //ScoreControllerオブジェクトを見つける
        _scoreController = GameObject.Find("ScoreController");
    }
    private void OnTriggerEnter(Collider other)
    {
        //ScoreControllerオブジェクトについてるScriptのメソッドを使用
        _scoreController.GetComponent<ScoreController>().AddScore(1);
        Destroy(gameObject); //削除
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
