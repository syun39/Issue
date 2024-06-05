using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] private int _speed = 50; //�v���C���[�̑��x
    [SerializeField] private Transform _goal; //�S�[���̍��W

    //�v���C���[���~�߂鎞�Ɏg���S�[���Ƃ̋���
    [SerializeField] private float _stopDistance = 20f;

    //bool _isStop = false;���̎g�������킩��Ȃ�����

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //�v���C���[�ƃS�[���̍��W�̍���_stopDistance�ȉ��̏ꍇ�ړ����~
        if (Vector3.Distance(transform.position, _goal.position) <= _stopDistance)
        {
            _rigidBody.velocity = Vector3.zero;
        }
        else
        {
            _rigidBody.velocity = transform.forward * _speed;
        }
    }
    //https://candle-stoplight-544.notion.site/4e021f226d584730b715626436ccc330
}
