using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //コメントアウトしているのは回答例
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] int _speed = 50; //プレイヤーの速度
    [SerializeField] float _jumpPower = 10f; // ジャンプ力
    [SerializeField] int _maxLife = 5;

    private int _currentLife;

    private bool _isGround;

    private bool _isMove;

    private string _inputBuffer = "";

    //bool _isStop = false;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _currentLife = _maxLife;
        _isMove = false;
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
            _currentLife--;

            if (_currentLife == 0)
            {
                SceneLoad("GameScene");
            }

            Destroy(other.gameObject);
            FindObjectOfType<LifeController>().LifeText();
        }
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
        if (collision.gameObject.name == "Goal" && collision.gameObject.name == "GoalWall") //オブジェクトの名前があっていた時
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
}
