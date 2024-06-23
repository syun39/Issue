using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _spawnRangeX = 10.0f; // x�����̐����͈�
    [SerializeField] private float _spawnRangeZ = 10.0f; // z�����̐����͈�
    [SerializeField] private float _fixedYPos = 1.0f; // y�����̌Œ�ʒu
    [SerializeField] private int _obstacles = 50; // ���������Q���̐�


    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new Vector3(randomX, _fixedYPos, randomZ);

            // �L���[�u�̐���
            Instantiate(_obstaclePrefab, spawnPosition, Quaternion.identity);

            //�A�C�e������
            /*for (int i = 0; i < 19; i++)
            {
                var item = Instantiate(_itemPrefab, _root);
                item.transform.position = new Vector3(0, 1, i * -5 - 5);
            }*/
        }
    }
}
