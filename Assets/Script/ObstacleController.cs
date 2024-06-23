using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x方向の生成範囲
    [SerializeField] float _spawnRangeZ = 10.0f; // z方向の生成範囲
    [SerializeField] float _fixedYPos = 1.0f; // y方向の固定位置
    [SerializeField] int _obstacles = 50; // 生成する障害物の数

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // 指定された数のキューブを生成
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPosition = new Vector3(randomX, _fixedYPos, randomZ);

            // 障害物の生成
            Instantiate(_obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
