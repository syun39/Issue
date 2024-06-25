using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab; // ��Q���̃v���n�u
    [SerializeField] float _spawnX = 1400f; // x�����̐����͈�
    [SerializeField] float _spawnZ = 90f; // z�����̐����͈�
    [SerializeField] float _posY = 0f; // y�����̌Œ�ʒu
    [SerializeField] int _obstacles = 100; // ���������Q���̐�

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // �w�肵�����̏�Q���𐶐�
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // ��Q���̐���
            Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
