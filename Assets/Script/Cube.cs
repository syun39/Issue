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
}
