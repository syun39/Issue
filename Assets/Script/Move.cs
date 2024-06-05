using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] private int _speed = 50; //プレイヤーの速度
    [SerializeField] private Transform _goal; //ゴールの座標

    //プレイヤーを止める時に使うゴールとの距離
    [SerializeField] private float _stopDistance = 20f;

    //bool _isStop = false;←の使い方がわからなかった

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーとゴールの座標の差が_stopDistance以下の場合移動を停止
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
