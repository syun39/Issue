using UnityEngine;

public class Move : MonoBehaviour
{
    //コメントアウトしているのは回答例
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] private int _speed = 50; //プレイヤーの速度
    [SerializeField] private Transform _goal; //ゴールの座標

    //プレイヤーを止める時に使うゴールとの距離
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
        　　//毎フレーム計算結果を更新
            _rigidBody.velocity = new Vector3(-Input.GetAxis("Horizontal") * _speed, 0, 10);
        }
        else
        {
            _rigidBody.velocity = new Vector3(0, 0, 0);
        }*/

        //プレイヤーとゴールの座標の差が_stopDistance以下の場合移動を停止
        if (Vector3.Distance(transform.position, _goal.position) <= _stopDistance)
        {
            _rigidBody.velocity = Vector3.zero;
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            //左右移動の速度
            Vector3 horizontalMove = transform.right * horizontal * _speed;
            Vector3 forwardMove = transform.forward * _speed;
            //ベクトルの合成
            _rigidBody.velocity = forwardMove + horizontalMove;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {　　　
        if (collision.gameObject.name == "Goal") //オブジェクトの名前があっていた時
        {
            _isStop = true;
        }
        //https://candle-stoplight-544.notion.site/4e021f226d584730b715626436ccc330
    }*/
}
