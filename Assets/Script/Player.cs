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
    [SerializeField] Text _startText; // �X�^�[�g�L�[��\������e�L�X�g
    [SerializeField] Text _secretText; // �X�s�[�h�������Ȃ镶��������ƕ\������e�L�X�g
    [SerializeField] Text _tipText; // �q���g��\������e�L�X�g
    [SerializeField] Text _moveText; // �ړ��̎d����\������e�L�X�g
    [SerializeField] Text _jumpText; // �W�����v�̎d����\������e�L�X�g
    [SerializeField] Button _retireButton; // ���^�C�A����{�^��
    [SerializeField] AudioClip _invincibleBGM; // ���G��Ԏ���BGM
    [SerializeField] AudioClip _normalBGM; // �ʏ펞��BGM
    [SerializeField] AudioClip _coinSe;
    [SerializeField] AudioClip _obstacleSe;
    [SerializeField] AudioClip _lifeRecoverySe;
    [SerializeField] AudioClip _invincibleSe;
    [SerializeField] AudioClip _jumpSe;

    private int _currentLife;

    private bool _isGround;

    private bool _isMove;

    private string _inputMozi = "";

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
        _secretText.gameObject.SetActive(false);
        _tipText.gameObject.SetActive(false);
        _jumpText.gameObject.SetActive(true);
        _moveText.gameObject.SetActive(true);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // �ʏ펞��BGM�����[�v������
        _audioSource.Play();
        _retireButton.gameObject.SetActive(false);
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
            _startText.gameObject.SetActive(false);
            _secretText.gameObject.SetActive(true);
            _tipText.gameObject.SetActive(true);
            _jumpText.gameObject.SetActive(false);
            _moveText.gameObject.SetActive(false);
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

            _retireButton.gameObject.SetActive(true);

            CheckForInput();
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
        _audioSource.PlayOneShot(_jumpSe);
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
                _audioSource.PlayOneShot(_obstacleSe);

                if (_currentLife == 0)
                {
                    SceneLoad("GameScene");
                }
            }

            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("Coin"))
        {
            _audioSource.PlayOneShot(_coinSe);
        }

        else if (other.CompareTag("LifeItem"))
        {
            RecoverLife();
            _audioSource.PlayOneShot(_lifeRecoverySe);
            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("LifeItemUp"))
        {
            RecoverLifeUp();
            _audioSource.PlayOneShot(_lifeRecoverySe);
            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }

        else if (other.CompareTag("Invincible"))
        {
            _audioSource.PlayOneShot(_invincibleSe);
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

    //���͕����`�F�b�N
    private void CheckForInput()
    {
        if (Input.anyKeyDown)
        {
            //�����ꂽ��������擾
            foreach (char c in Input.inputString)
            {
                //�A���t�@�x�b�g���ǂ���
                if (char.IsLetter(c))
                {
                    _inputMozi += char.ToLower(c); //�������������ɕϊ�

                    //�l����������ێ�
                    if (_inputMozi.Length > 4)
                    {
                        _inputMozi = _inputMozi.Substring(_inputMozi.Length - 4);
                    }

                    //�l��������v������
                    if (_inputMozi.Equals("miku"))
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
        _audioSource.loop = false; // ���G��Ԃ�BGM�����[�v���Ȃ�
        _audioSource.Play();
    }

    private void NoActivateInvincible()
    {
        _isInvincible = false;
        _invincibleText.gameObject.SetActive(false); // ���G��Ԃ̃e�L�X�g���\���ɂ���
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // �ʏ펞��BGM�����[�v����
        _audioSource.Play();
    }
}
