using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //コメントアウトしているのは回答例

    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] int _speed = 50; //プレイヤーの速度
    [SerializeField] float _jumpPower = 10f; // ジャンプ力
    [SerializeField] int _maxLife = 5; // 最大ライフ
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
    [SerializeField] AudioClip _coinSe; // コイン獲得時の効果音
    [SerializeField] AudioClip _obstacleSe; // 障害物衝突時の効果音
    [SerializeField] AudioClip _lifeRecoverySe; // ライフアイテム獲得時の効果音
    [SerializeField] AudioClip _invincibleSe; // 無敵アイテム獲得時の効果音
    [SerializeField] AudioClip _jumpSe; // ジャンプした時の効果音

    private int _currentLife; // 現在のライフの数

    private bool _isGround; // 地面に着いているか

    private bool _isMove; // プレイヤーが動いているか

    private string _inputMozi = ""; // 特定の四文字を格納

    private bool _isInvincible; // 無敵状態かどうか

    private float _invincibleTimer; // 無敵状態時のタイマー

    private AudioSource _audioSource;

    //bool _isStop = false;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _currentLife = _maxLife;
        _isMove = false;
        _isInvincible = false;
        _invincibleTimer = 0.0f;
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _secretText.gameObject.SetActive(false); // 特定の四文字があることのテキストを非表示にする
        _tipText.gameObject.SetActive(false); // 特定の四文字のヒントテキストを非表示にする
        _jumpText.gameObject.SetActive(true); // ジャンプの仕方のテキストを表示する
        _moveText.gameObject.SetActive(true); // 移動方法のテキストを表示する
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // 通常時のBGMをループさせる
        _audioSource.Play();
        _retireButton.gameObject.SetActive(false); // リタイアボタンを非表示にする
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

        //　スペースキーが押されたらプレイヤーが動く
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isMove = true;
        }

        if (_isMove)
        {
            _startText.gameObject.SetActive(false); // スタートキーを表示するテキストを非表示にする
            _secretText.gameObject.SetActive(true);// 特定の四文字があることのテキストを表示する
            _tipText.gameObject.SetActive(true); // 特定の四文字のヒントテキストを表示する
            _jumpText.gameObject.SetActive(false);// ジャンプの仕方のテキストを非表示にする
            _moveText.gameObject.SetActive(false); // 移動方法のテキストを非表示にする

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

            _retireButton.gameObject.SetActive(true); // リタイアボタンを表示する

            CheckForInput();
        }

        // 無敵モードの時間をカウントダウン
        if (_isInvincible)
        {
            _invincibleTimer -= Time.deltaTime;
            if (_invincibleTimer <= 0)
            {
                NoActivateInvincible();
            }

            else
            {
                _invincibleText.text = "無敵時間" + _invincibleTimer.ToString("F1");
            }
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
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
            // 無敵状態じゃなかったら
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

    /// <summary>
    /// ライフ回復
    /// </summary>
    private void RecoverLife()
    {
        //最大ライフを超えないように
        _currentLife = Mathf.Min(_currentLife + _lifeRecovery, _maxLife);
    }

    /// <summary>
    /// ライフ回復回復量が2のやつ
    /// </summary>
    private void RecoverLifeUp()
    {
        //最大ライフを超えないように
        _currentLife = Mathf.Min(_currentLife + _lifeRecoveryUp, _maxLife);
    }

    /// <summary>
    /// 現在のライフを取得
    /// </summary>
    /// <returns></returns>
    public int GetCurrentLife()
    {
        return _currentLife;
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="sceneName"></param>
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

    /// <summary>
    /// 特定の四文字の入力文字チェック
    /// </summary>
    //後で一回入力されたらうけつけないようにする
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

    /// <summary>
    /// 無敵状態
    /// </summary>
    public void ActivateInvincible()
    {
        _isInvincible = true;
        _invincibleTimer = _invincibleTime;
        _invincibleText.gameObject.SetActive(true); // 無敵状態のテキストを表示する
        _audioSource.clip = _invincibleBGM;
        _audioSource.loop = false; // 無敵状態のBGMをループしない
        _audioSource.Play();
    }

    /// <summary>
    /// 無敵状態じゃないとき
    /// </summary>
    private void NoActivateInvincible()
    {
        _isInvincible = false;
        _invincibleText.gameObject.SetActive(false); // 無敵状態のテキストを非表示にする
        _audioSource.clip = _normalBGM;
        _audioSource.loop = true; // 通常時のBGMをループする
        _audioSource.Play();
    }
}
