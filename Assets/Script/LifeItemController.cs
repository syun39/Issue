using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    [SerializeField] GameObject _lifeItemPrefab; // �񕜃A�C�e���̃v���n�u
    [SerializeField] GameObject _lifeItemUpPrefab; // �񕜃A�C�e���i2�񕜁j�̃v���n�u
    [SerializeField] float _spawnX = 1000f; // x�����̐����͈�
    [SerializeField] float _spawnZ = 90f; // z�����̐����͈�
    [SerializeField] float _posY = 10f; // y�����̌Œ�ʒu
    [SerializeField] int _lifeItem = 10; // ��������񕜃A�C�e���̐�
    [SerializeField] int _lifeItemUp = 5; // ��������񕜃A�C�e���i2�񕜁j�̐�

    void Start()
    {
        for (int i = 0; i < _lifeItem; i++) // �w�肵�����̉񕜃A�C�e���𐶐�
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);
            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // �񕜃A�C�e���̐���
            Instantiate(_lifeItemPrefab, spawnPos, Quaternion.Euler(0, -180, 0));

        }

        for (int i = 0; i < _lifeItemUp; i++) // �w�肵�����̉񕜃A�C�e���i2��)�𐶐�
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // �񕜃A�C�e���i2��)�̐���
            Instantiate(_lifeItemUpPrefab, spawnPos, Quaternion.Euler(0, -180, 0));
        }
    }
}
