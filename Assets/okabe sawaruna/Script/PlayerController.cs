using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _dashSpeed = 5f;
    [SerializeField] float _jumpPower = 10;

    [SerializeField] CinemachineVirtualCamera _camera;
    SpriteRenderer _playerSprite;

    float _dash = 1;
    public Rigidbody2D _rb;
    private string _isGroundTag = "IsGround";
    bool IsGround = false;
    public static PlayerController Instance;


    private void Awake()  //シングルトン化
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _isGroundTag)
        {
            IsGround = true;
            if (TryGetComponent<PlayerAnimator>(out PlayerAnimator animator))
            {
                animator.IsGround();
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(5 * Vector2.up, ForceMode2D.Impulse);
            Debug.Log("Stomp_Hit");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGround = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHit();
        }
    }
    protected void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
        CinemachineVirtualCamera camera = GameObject.Find("PlayerCamera").gameObject.GetComponent<CinemachineVirtualCamera>();
        camera.Follow = this.transform;

    }
    public void Update()
    {
        if (!GameManager.instance.IsGameOver)
        {
            float h = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(h * _speed * _dash, _rb.velocity.y);
            if (Input.GetButtonDown("Jump") && IsGround == true)
            {
                Jump();
                Debug.Log("ジャンプ");
            }
            if (Input.GetKey(KeyCode.Return) && IsGround == true)
            {
                _dash = _dashSpeed;
            }
            else
            {
                _dash = 1;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                FireAttack();
            }
        }
    }
    public void Jump()
    {
        IsGround = false;
        _rb.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
    public virtual void FireAttack()
    {
    }
    public virtual void EnemyHit()
    {
        _playerSprite.color = Color.red;
        GameManager.instance.GameOver();
        Debug.Log("黒田が死んだ");
    }
}