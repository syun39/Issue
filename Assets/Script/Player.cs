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
    [SerializeField] Text _startText; // スタートキーを表示するテキスト
    [SerializeField] Text _secretText; // スピードが早くなる文字があると表示するテキスト
    [SerializeField] Text _tipText; // ヒントを表示するテキスト
    [SerializeField] Text _moveText; // 移動の仕方を表示するテキスト
    [SerializeField] Text _jumpText; // ジャンプの仕方を表示するテキスト
    [SerializeField] Button _retireButton; // リタイアするボタン
    [SerializeField] AudioClip _invincibleBGM; // 無敵状態時のBGM
    [SerializeField] AudioClip _normalBGM; // 通常時のBGM
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
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _secretText.gameObject.SetActive(false);
        _tipText.gameObject.SetActive(false);
        _jumpText.gameObject.SetActive(true);
        _moveText.gameObject.SetActive(true);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // 通常時のBGMをループさせる
        _audioSource.Play();
        _retireButton.gameObject.SetActive(false);
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
            _startText.gameObject.SetActive(false);
            _secretText.gameObject.SetActive(true);
            _tipText.gameObject.SetActive(true);
            _jumpText.gameObject.SetActive(false);
            _moveText.gameObject.SetActive(false);
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

            _retireButton.gameObject.SetActive(true);

            CheckForInput();
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

    //入力文字チェック
    private void CheckForInput()
    {
        if (Input.anyKeyDown)
        {
            //押された文字列を取得
            foreach (char c in Input.inputString)
            {
                //アルファベットかどうか
                if (char.IsLetter(c))
                {
                    _inputMozi += char.ToLower(c); //文字を小文字に変換

                    //四文字だけを保持
                    if (_inputMozi.Length > 4)
                    {
                        _inputMozi = _inputMozi.Substring(_inputMozi.Length - 4);
                    }

                    //四文字が一致したら
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
        _invincibleText.gameObject.SetActive(true); // 無敵状態のテキストを表示する
        _audioSource.clip = _invincibleBGM;
        _audioSource.loop = false; // 無敵状態のBGMをループしない
        _audioSource.Play();
    }

    private void NoActivateInvincible()
    {
        _isInvincible = false;
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // 通常時のBGMをループする
        _audioSource.Play();
    }
}
