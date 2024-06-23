using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�R�����g�A�E�g���Ă���͉̂񓚗�

    [SerializeField] GameObject _cubePrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x�����̐����͈�
    [SerializeField] float _spawnRangeZ = 10.0f; // z�����̐����͈�
    [SerializeField] float _fixedYPos = 1.0f; // y�����̌Œ�ʒu
    [SerializeField] int _cubes = 100; // ��������L���[�u�̐�


    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _cubes; i++) // �w�肳�ꂽ���̃L���[�u�𐶐�
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPosition = new Vector3(randomX, _fixedYPos, randomZ);

            // �L���[�u�̐���
            Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);

            //�A�C�e������
            /*for (int i = 0; i < 19; i++)
            {
                var item = Instantiate(_itemPrefab, _root);
                item.transform.position = new Vector3(0, 1, i * -5 - 5);
            }*/
        }
    }
}
