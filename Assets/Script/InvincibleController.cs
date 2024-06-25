using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    [SerializeField] GameObject _invinciblePrefab; // ���G�A�C�e���̃v���n�u
    [SerializeField] float _spawnX = 1000f; // x�����̐����͈�
    [SerializeField] float _spawnZ = 90f; // z�����̐����͈�
    [SerializeField] float _posY = 10f; // y�����̌Œ�ʒu
    [SerializeField] int _invincibles = 1; // �������閳�G�A�C�e���̐�

    void Start()
    {
        for (int i = 0; i < _invincibles; i++) // �w�肵�����̖��G�A�C�e���𐶐�
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            //���G�A�C�e���̐���
            Instantiate(_invinciblePrefab, spawnPos, Quaternion.identity);
        }
    }
}
