using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject _scoreController;

    private void Start()
    {
        //ScoreController�I�u�W�F�N�g��������
        _scoreController = GameObject.Find("ScoreController");
    }
    private void OnTriggerEnter(Collider other)
    {
        //ScoreController�I�u�W�F�N�g�ɂ��Ă�Script�̃��\�b�h���g�p
        _scoreController.GetComponent<ScoreController>().AddScore(1);
        Destroy(gameObject); //�폜
    }
}
