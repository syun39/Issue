using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Text _lifeText; // �c�胉�C�t�e�L�X�g

    void Start()
    {
        LifeText();
    }

    /// <summary>
    /// �e�L�X�g���X�V����
    /// </summary>
    public void LifeText()
    {
        // �v���C���[�N���X��T��
        var player = FindObjectOfType<Player>();
        _lifeText.text = "Life " + player.GetCurrentLife().ToString(); // �e�L�X�g�Ɏc�胉�C�t��\��
    }
}
