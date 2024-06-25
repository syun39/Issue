using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Text _lifeText; // 残りライフテキスト

    void Start()
    {
        LifeText();
    }

    /// <summary>
    /// テキストを更新する
    /// </summary>
    public void LifeText()
    {
        // プレイヤークラスを探す
        var player = FindObjectOfType<Player>();
        _lifeText.text = "Life " + player.GetCurrentLife().ToString(); // テキストに残りライフを表示
    }
}
