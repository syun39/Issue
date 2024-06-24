using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //コメントアウトしているのは回答例
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] int _speed = 50; //プレイヤーの速度
    [SerializeField] float _jumpPower = 10f; // ジャンプ力
    [SerializeField] int _maxLife = 5;
    [SerializeField] int _lifeRecovery = 1; // 回復するライフの量
    [SerializeField] int _lifeRecoveryUp = 2; // 回復するライフの量
    [SerializeField] float _invincibleTime = 5.0f; // 無敵モードの持続時間
    [SerializeField] Text _invincibleText; // 無敵状態の残り時間を表示するテキスト
    [SerializeField] AudioClip _invincibleBGM; // 無敵状態時のBGM
    [SerializeField] AudioClip _normalBGM; // 通常時のBGM

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
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _normalBGM;
        _audioSource.Play();
    }

    void Update()
    {
        /*if (_isStop == false)
        {
        　　//毎フレーム計算結果を更新
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
            //左右移動の速度
            Vector3 horizontalMove = transform.right * horizontal * _speed;
            Vector3 forwardMove = transform.forward * _speed;
            //ベクトルの合成
            _rigidBody.velocity = forwardMove + horizontalMove;

            if (_isGround && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            CheckForMikuInput();
        }

        // 無敵モードの時間をカウントダウン
        if (_isInvincible)
        {
            _invincibilityTimer -= Time.deltaTime;
            if (_invincibilityTimer <= 0)
            {
                NoActivateInvincible();
            }

            else
            {
                _invincibleText.text = "無敵時間" + _invincibilityTimer.ToString("F1");
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
        //最大ライフを超えないように
        _currentLife = Mathf.Min(_currentLife + _lifeRecovery, _maxLife);
    }
    //回復量が2のやつ
    private void RecoverLifeUp()
    {
        //最大ライフを超えないように
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
        if (collision.gameObject.name == "Goal" || collision.gameObject.name == "GoalWall") //オブジェクトの名前があっていた時
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
        _invincibleText.gameObject.SetActive(true); // 無敵状態のテキストを表示する
        _audioSource.clip = _invincibleBGM;
        _audioSource.Play();
    }

    private void NoActivateInvincible()
    {
        _isInvincible = false;
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _audioSource.clip = _normalBGM;
        _audioSource.Play();
    }
}
