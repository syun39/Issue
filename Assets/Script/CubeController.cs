using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�R�����g�A�E�g���Ă���͉̂񓚗�

    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private float _xPos = 424; //�����̃X�^�[�g�n�_
    [SerializeField] private float _distance = 848; //�X�^�[�g����S�[���܂ł̋���
    [SerializeField] private float _posInterval = 12; //cube��scale��7�Ȃ̂�5m�̊Ԋu�������邽�߂�7+5

    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _distance / _posInterval; i++) //�X�^�[�g����S�[���܂ł̋����𐶐��Ԋu�Ŋ���
        {
            _xPos -= _posInterval;
            Instantiate(_cubePrefab, new Vector3(_xPos, 8, 0), Quaternion.identity);
        }

        //�A�C�e������
        /*for (int i = 0; i < 19; i++)
        {
            var item = Instantiate(_itemPrefab, _root);
            item.transform.position = new Vector3(0, 1, i * -5 - 5);
        }*/
    }
}
