using UnityEngine;
using UnityEngine.UI;

//‰ñ“š—á@ScoreManager@ScoreUI‚Í‰ñ“š—á‚ÌScript
public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _text;

    void Update()
    {
        _text.text = ScoreManager.Instance.GetScore().ToString();
    }
}
