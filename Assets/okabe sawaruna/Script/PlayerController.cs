using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _dashSpeed = 5f;
    [SerializeField] float _jumpPower = 10;
    float _dash = 1;
    Rigidbody2D _rb;
    private string _isGroundTag = "IsGround";
    bool IsGround = false;

    public static PlayerController Instance;

    private void Awake()  //ƒVƒ“ƒOƒ‹ƒgƒ“‰»
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == _isGroundTag)
        {
            IsGround = true;
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
        _rb.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
}

