using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject _scoreController;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �X�R�A�R���g���[���N���X��T��
            var _scoreController = FindObjectOfType<ScoreController>();
            // �X�R�A��1���Z
            _scoreController.AddScore(1);
            Destroy(gameObject); //�폜
        }
    }

    //�񓚗�
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }*/
}
