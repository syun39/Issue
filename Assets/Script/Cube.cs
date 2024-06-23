using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] ScoreController _scoreController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ScoreController�I�u�W�F�N�g�ɂ��Ă�Script�̃��\�b�h���g�p
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
