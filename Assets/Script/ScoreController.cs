using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] int _score; //スコア
    [SerializeField] Text _scoreText; // スコアテキスト
    void Start()
    {
        _score = 0;
    }
    void Update()
    {
        _scoreText.text = _score.ToString();
    }
    /// <summary>
    ///  //スコアを加算
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        _score += value;
    }
}
