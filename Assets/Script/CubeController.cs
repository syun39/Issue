using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private float _xPos = 424; //生成のスタート地点
    [SerializeField] private float _distance = 848; //スタートからゴールまでの距離
    [SerializeField] private float _posInterval = 12; //cubeのscaleが7なので5mの間隔をあけるために7+5
    void Start()
    {
        for (int i = 0; i < _distance / _posInterval; i++) //スタートからゴールまでの距離を生成間隔で割る
        {
            _xPos -= _posInterval;
            Instantiate(_cubePrefab, new Vector3(_xPos, 8, 0), Quaternion.identity);
        }
    }
}
