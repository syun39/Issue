using UnityEngine;

public class CoinController : MonoBehaviour
{
    //�R�����g�A�E�g���Ă���͉̂񓚗�

    [SerializeField] GameObject _coinPrefab; // �R�C���̃v���n�u
    [SerializeField] float _spawnX = 1400f; // x�����̐����͈�
    [SerializeField] float _spawnZ = 90f; // z�����̐����͈�
    [SerializeField] float _posY = 10f; // y�����̌Œ�ʒu
    [SerializeField] int _coins = 300; // ��������R�C���̐�


    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _coins; i++) // �w�肵�����̃R�C���𐶐�
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // �����_���Ȉʒu��ݒ� (x��z�̓����_���Ay�͌Œ�)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // �R�C���̐���
            Instantiate(_coinPrefab, spawnPos, Quaternion.identity);

            //�A�C�e������
            /*for (int i = 0; i < 19; i++)
            {
                var item = Instantiate(_itemPrefab, _root);
                item.transform.position = new Vector3(0, 1, i * -5 - 5);
            }*/
        }
    }
}
