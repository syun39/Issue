using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab; // 障害物のプレハブ
    [SerializeField] float _spawnX = 1400f; // x方向の生成範囲
    [SerializeField] float _spawnZ = 90f; // z方向の生成範囲
    [SerializeField] float _posY = 0f; // y方向の固定位置
    [SerializeField] int _obstacles = 100; // 生成する障害物の数

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // 指定した数の障害物を生成
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // 障害物の生成
            Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
