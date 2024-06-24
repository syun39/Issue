using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    [SerializeField] GameObject _invinciblePrefab;
    [SerializeField] float _spawnRangeX = 10.0f; // x方向の生成範囲
    [SerializeField] float _spawnRangeZ = 10.0f; // z方向の生成範囲
    [SerializeField] float _fixedYPos = 1.0f; // y方向の固定位置
    [SerializeField] int _obstacles = 3; // 生成する障害物の数

    void Start()
    {
        for (int i = 0; i < _obstacles; i++) // 指定された数のキューブを生成
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPosition = new(randomX, _fixedYPos, randomZ);

            //無敵アイテムの生成
            Instantiate(_invinciblePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
