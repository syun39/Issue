//シングルトン（このやり方を覚える）
//回答例
public class ScoreManager
{
    static ScoreManager _instance = new ScoreManager();
    public static ScoreManager Instance => _instance;
    private ScoreManager() { }　
　　//上の三行が大事

    int _score = 0;

    public void AddScore(int score)
    {
        _score += score;
    }
    public int GetScore()
    {
        return _score;
    }
}
