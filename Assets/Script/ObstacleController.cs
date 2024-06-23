using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x�����̐����͈�
    [SerializeField] float _spawnRangeZ = 10.0f; // z�����̐����͈�
    [SerializeField] float _fixedYPos = 1.0f; // y�����̌Œ�ʒu
    [SerializeField] int _obstacles = 50; // ���������Q���̐�

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new Vector3(randomX, _fixedYPos, randomZ);

            // ��Q���̐���
            Instantiate(_obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
