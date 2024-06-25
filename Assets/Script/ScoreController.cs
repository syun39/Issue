using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] int _score; //�X�R�A
    [SerializeField] Text _scoreText; // �X�R�A�e�L�X�g
    void Start()
    {
        _score = 0;
    }
    void Update()
    {
        _scoreText.text = _score.ToString();
    }
    /// <summary>
    ///  //�X�R�A�����Z
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        _score += value;
    }
}
