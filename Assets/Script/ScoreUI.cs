using UnityEngine;
using UnityEngine.UI;

//回答例　ScoreManager　ScoreUIは回答例のScript
public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _text;

    void Update()
    {
        _text.text = ScoreManager.Instance.GetScore().ToString();
    }
}
