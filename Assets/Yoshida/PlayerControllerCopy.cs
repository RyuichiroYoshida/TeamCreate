using UnityEngine;

public class PlayerControllerCopy : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _dashSpeed = 5f;
    [SerializeField] float _jumpPower = 10;
    float _dash = 1;
    Rigidbody2D _rb;
    private string _isGroundTag = "IsGround";
    bool IsGround = false;

    public static PlayerControllerCopy Instance;

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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && IsGround == false)
        {

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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGround = false;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
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

    }
    public void Jump()
    {
        IsGround = false;
        _rb.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
}

