using UnityEngine;

public class LifeItemController : MonoBehaviour
{
    [SerializeField] GameObject _lifeItemPrefab; // 回復アイテムのプレハブ
    [SerializeField] GameObject _lifeItemUpPrefab; // 回復アイテム（2回復）のプレハブ
    [SerializeField] float _spawnX = 1000f; // x方向の生成範囲
    [SerializeField] float _spawnZ = 90f; // z方向の生成範囲
    [SerializeField] float _posY = 10f; // y方向の固定位置
    [SerializeField] int _lifeItem = 10; // 生成する回復アイテムの数
    [SerializeField] int _lifeItemUp = 5; // 生成する回復アイテム（2回復）の数

    void Start()
    {
        for (int i = 0; i < _lifeItem; i++) // 指定した数の回復アイテムを生成
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);
            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // 回復アイテムの生成
            Instantiate(_lifeItemPrefab, spawnPos, Quaternion.Euler(0, -180, 0));

        }

        for (int i = 0; i < _lifeItemUp; i++) // 指定した数の回復アイテム（2回復)を生成
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // 回復アイテム（2回復)の生成
            Instantiate(_lifeItemUpPrefab, spawnPos, Quaternion.Euler(0, -180, 0));
        }
    }
}
