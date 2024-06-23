using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    [SerializeField] GameObject _lifeItemPrefab;
    [SerializeField] GameObject _lifeItemUpPrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x�����̐����͈�
    [SerializeField] float _spawnRangeZ = 10.0f; // z�����̐����͈�
    [SerializeField] float _fixedYPos = 1.0f; // y�����̌Œ�ʒu
    [SerializeField] int _lifeItem = 10; // ��������񕜃A�C�e���̐�
    [SerializeField] int _lifeItemUp = 5; // ��������񕜃A�C�e���i2�񕜁j�̐�

    void Start()
    {
        for (int i = 0; i < _lifeItem; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            // �L���[�u�̐���
            Instantiate(_lifeItemPrefab, spawnPosition, Quaternion.identity);

        }

        for (int i = 0; i < _lifeItemUp; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            // �L���[�u�̐���
            Instantiate(_lifeItemUpPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
