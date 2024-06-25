using UnityEngine;

public class CoinController : MonoBehaviour
{
    //コメントアウトしているのは回答例

    [SerializeField] GameObject _coinPrefab; // コインのプレハブ
    [SerializeField] float _spawnX = 1400f; // x方向の生成範囲
    [SerializeField] float _spawnZ = 90f; // z方向の生成範囲
    [SerializeField] float _posY = 10f; // y方向の固定位置
    [SerializeField] int _coins = 300; // 生成するコインの数


    //[SerializeField] Transform _root;
    //[SerializeField] private GameObject _itemPrefab;
    void Start()
    {
        for (int i = 0; i < _coins; i++) // 指定した数のコインを生成
        {
            float randomX = Random.Range(-_spawnX, _spawnX);
            float randomZ = Random.Range(-_spawnZ, _spawnZ);

            // ランダムな位置を設定 (xとzはランダム、yは固定)
            Vector3 spawnPos = new(randomX, _posY, randomZ);

            // コインの生成
            Instantiate(_coinPrefab, spawnPos, Quaternion.identity);

            //アイテム生成
            /*for (int i = 0; i < 19; i++)
            {
                var item = Instantiate(_itemPrefab, _root);
                item.transform.position = new Vector3(0, 1, i * -5 - 5);
            }*/
        }
    }
}
