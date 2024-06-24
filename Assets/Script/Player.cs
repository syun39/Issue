using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //�R�����g�A�E�g���Ă���͉̂񓚗�
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] int _speed = 50; //�v���C���[�̑��x
    [SerializeField] float _jumpPower = 10f; // �W�����v��
    [SerializeField] int _maxLife = 5;
    [SerializeField] int _lifeRecovery = 1; // �񕜂��郉�C�t�̗�
    [SerializeField] int _lifeRecoveryUp = 2; // �񕜂��郉�C�t�̗�
    [SerializeField] float _invincibleTime = 5.0f; // ���G���[�h�̎�������
    [SerializeField] Text _invincibleText; // ���G��Ԃ̎c�莞�Ԃ�\������e�L�X�g
    [SerializeField] AudioClip _invincibleBGM; // ���G��Ԏ���BGM
    [SerializeField] AudioClip _normalBGM; // �ʏ펞��BGM

    private int _currentLife;

    private bool _isGround;

    private bool _isMove;

    private string _inputBuffer = "";

    private bool _isInvincible;

    private float _invincibilityTimer;

    private AudioSource _audioSource;

    //bool _isStop = false;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _currentLife = _maxLife;
        _isMove = false;
        _isInvincible = false;
        _invincibilityTimer = 0.0f;
        _invincibleText.gameObject.SetActive(false); // ���G��Ԃ̃e�L�X�g���\���ɂ���
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _normalBGM;
        _audioSource.Play();
    }

    void Update()
    {
        /*if (_isStop == false)
        {
        �@�@//���t���[���v�Z���ʂ��X�V
            _rigidBody.velocity = new Vector3(-Input.GetAxis("Horizontal") * _speed, 0, 10);
        }
        else
        {
            _rigidBody.velocity = new Vector3(0, 0, 0);
        }*/

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isMove = true;
        }

        if (_isMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            //���E�ړ��̑��x
            Vector3 horizontalMove = transform.right * horizontal * _speed;
            Vector3 forwardMove = transform.forward * _speed;
            //�x�N�g���̍���
            _rigidBody.velocity = forwardMove + horizontalMove;

            if (_isGround && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            CheckForMikuInput();
        }

        // ���G���[�h�̎��Ԃ��J�E���g�_�E��
        if (_isInvincible)
        {
            _invincibilityTimer -= Time.deltaTime;
            if (_invincibilityTimer <= 0)
            {
                NoActivateInvincible();
            }

            else
            {
                _invincibleText.text = "���G����" + _invincibilityTimer.ToString("F1");
            }
        }
    }

    private void Jump()
    {
        _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        _isGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (!_isInvincible)
            {
                _currentLife--;

                if (_currentLife == 0)
                {
                    SceneLoad("GameScene");
                }
            }

            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("LifeItem"))
        {
            RecoverLife();
            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("LifeItemUp"))
        {
            RecoverLifeUp();
            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("Invincible"))
        {
            ActivateInvincible();
            Destroy(other.gameObject);
        }
    }

    private void RecoverLife()
    {
        //�ő僉�C�t�𒴂��Ȃ��悤��
        _currentLife = Mathf.Min(_currentLife + _lifeRecovery, _maxLife);
    }
    //�񕜗ʂ�2�̂��
    private void RecoverLifeUp()
    {
        //�ő僉�C�t�𒴂��Ȃ��悤��
        _currentLife = Mathf.Min(_currentLife + _lifeRecoveryUp, _maxLife);
    }

    public int GetCurrentLife()
    {
        return _currentLife;
    }

    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal" || collision.gameObject.name == "GoalWall") //�I�u�W�F�N�g�̖��O�������Ă�����
        {
            _rigidBody.velocity = Vector3.zero;
            SceneLoad("GameClear");
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }


    private void CheckForMikuInput()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (char.IsLetter(c))
                {
                    _inputBuffer += char.ToLower(c);
                    if (_inputBuffer.Length > 4)
                    {
                        _inputBuffer = _inputBuffer.Substring(_inputBuffer.Length - 4);
                    }

                    if (_inputBuffer.Equals("miku"))
                    {
                        _speed *= 3;
                    }
                }
            }
        }
    }

    public void ActivateInvincible()
    {
        _isInvincible = true;
        _invincibilityTimer = _invincibleTime;
        _invincibleText.gameObject.SetActive(true); // ���G��Ԃ̃e�L�X�g��\������
        _audioSource.clip = _invincibleBGM;
        _audioSource.Play();
    }

    private void NoActivateInvincible()
    {
        _isInvincible = false;
        _invincibleText.gameObject.SetActive(false); // ���G��Ԃ̃e�L�X�g���\���ɂ���
        _audioSource.clip = _normalBGM;
        _audioSource.Play();
    }
}
