using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Text lifeText; // UI テキストオブジェクトへの参照

    void Start()
    {
        LifeText(); // 最初にテキストを更新する
    }

    // テキストを更新するメソッド
    public void LifeText()
    {
        // プレイヤーコントローラーを探して参照する
        var playerController = FindObjectOfType<Player>();

        // プレイヤーコントローラーが見つかった場合にのみ残りライフを表示する
        if (playerController != null)
        {
            lifeText.text = "Life " + playerController.GetCurrentLife().ToString(); // テキストに残りライフを表示
        }
    }
}
