using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    [SerializeField] GameObject _invinciblePrefab; // 無敵アイテムのプレハブ
    [SerializeField] float _spawnX = 1000f; // x方向の生成範囲
    [SerializeField] float _spawnZ = 90f; // z方向の生成範囲
    [SerializeField] float _posY = 10f; // y方向の固定位置
    [SerializeField] int _invincibles = 1; // 生成する無敵アイテムの数

    void Start()
    {
        for (int i = 0; i < _invincibles; i++) // 指定した数の無敵アイテムを生成
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            //無敵アイテムの生成
            Instantiate(_invinciblePrefab, spawnPos, Quaternion.identity);
        }
    }
}
