using UnityEngine;
using UnityEngine.UI;

//�񓚗�@ScoreManager�@ScoreUI�͉񓚗��Script
public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _text;

    void Update()
    {
        _text.text = ScoreManager.Instance.GetScore().ToString();
    }
}
