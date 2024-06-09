using UnityEngine;

public class Move : MonoBehaviour
{
    //�R�����g�A�E�g���Ă���͉̂񓚗�
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] private int _speed = 50; //�v���C���[�̑��x
    [SerializeField] private Transform _goal; //�S�[���̍��W

    //�v���C���[���~�߂鎞�Ɏg���S�[���Ƃ̋���
    [SerializeField] private float _stopDistance = 20f;

    //bool _isStop = false;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*if (_isStop == false)
        {
        �@�@//���t���[���v�Z���ʂ��X�V
            _rigidBody.velocity = new Vector3(-Input.GetAxis("Horizontal") * _speed, 0, 10);
        }
        else
        {
            _rigidBody.velocity = new Vector3(0, 0, 0);
        }*/

        //�v���C���[�ƃS�[���̍��W�̍���_stopDistance�ȉ��̏ꍇ�ړ����~
        if (Vector3.Distance(transform.position, _goal.position) <= _stopDistance)
        {
            _rigidBody.velocity = Vector3.zero;
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            //���E�ړ��̑��x
            Vector3 horizontalMove = transform.right * horizontal * _speed;
            Vector3 forwardMove = transform.forward * _speed;
            //�x�N�g���̍���
            _rigidBody.velocity = forwardMove + horizontalMove;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {�@�@�@
        if (collision.gameObject.name == "Goal") //�I�u�W�F�N�g�̖��O�������Ă�����
        {
            _isStop = true;
        }
        //https://candle-stoplight-544.notion.site/4e021f226d584730b715626436ccc330
    }*/
}
