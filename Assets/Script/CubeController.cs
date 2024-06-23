using UnityEngine;

public class CubeController : MonoBehaviour
{
    //コメントアウトしているのは回答例

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _spawnRangeX = 10.0f; // x方向の生成範囲
    [SerializeField] private float _spawnRangeZ = 10.0f; // z方向の生成範囲
    [SerializeField] private float _fixedYPos = 1.0f; // y方向の固定位置
    [SerializeField] private int _numberOfCubes = 100; // 生成するキューブの数


    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _numberOfCubes; i++) // 指定された数のキューブを生成
        {
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            float randomZ = Random.Range(-_spawnRangeZ, _spawnRangeZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPosition = new Vector3(randomX, _fixedYPos, randomZ);

            // キューブの生成
            Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);

            //アイテム生成
            /*for (int i = 0; i < 19; i++)
            {
                var item = Instantiate(_itemPrefab, _root);
                item.transform.position = new Vector3(0, 1, i * -5 - 5);
            }*/
        }
    }
}
