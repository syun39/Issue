using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Text lifeText; // UI �e�L�X�g�I�u�W�F�N�g�ւ̎Q��

    void Start()
    {
        LifeText(); // �ŏ��Ƀe�L�X�g���X�V����
    }

    // �e�L�X�g���X�V���郁�\�b�h
    public void LifeText()
    {
        // �v���C���[�R���g���[���[��T���ĎQ�Ƃ���
        var playerController = FindObjectOfType<Player>();

        // �v���C���[�R���g���[���[�����������ꍇ�ɂ̂ݎc�胉�C�t��\������
        if (playerController != null)
        {
            lifeText.text = "Life " + playerController.GetCurrentLife().ToString(); // �e�L�X�g�Ɏc�胉�C�t��\��
        }
    }
}
