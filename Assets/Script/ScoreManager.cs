//�V���O���g���i���̂������o����j
//�񓚗�
public class ScoreManager
{
    static ScoreManager _instance = new ScoreManager();
    public static ScoreManager Instance => _instance;
    private ScoreManager() { }�@
�@�@//��̎O�s���厖

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
