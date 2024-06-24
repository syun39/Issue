using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    [SerializeField] GameObject _invinciblePrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x�����̐����͈�
    [SerializeField] float _spawnRangeZ = 10.0f; // z�����̐����͈�
    [SerializeField] float _fixedYPos = 1.0f; // y�����̌Œ�ʒu
    [SerializeField] int _obstacles = 3; // ���������Q���̐�

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            //���G�A�C�e���̐���
            Instantiate(_invinciblePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
