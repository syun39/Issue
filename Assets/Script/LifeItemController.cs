using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    [SerializeField] GameObject _lifeItemPrefab;
    [SerializeField] GameObject _lifeItemUpPrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x方向の生成範囲
    [SerializeField] float _spawnRangeZ = 10.0f; // z方向の生成範囲
    [SerializeField] float _fixedYPos = 1.0f; // y方向の固定位置
    [SerializeField] int _lifeItem = 10; // 生成する回復アイテムの数
    [SerializeField] int _lifeItemUp = 5; // 生成する回復アイテム（2回復）の数

    void Start()
    {
        for (int i = 0; i < _lifeItem; i++) // 指定された数のキューブを生成
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            // キューブの生成
            Instantiate(_lifeItemPrefab, spawnPosition, Quaternion.identity);

        }

        for (int i = 0; i < _lifeItemUp; i++) // 指定された数のキューブを生成
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            // キューブの生成
            Instantiate(_lifeItemUpPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
