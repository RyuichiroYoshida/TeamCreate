using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _dashSpeed = 5f;
    float _dash = 1;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h * _speed * _dash, _rb.velocity.y);

        if (Input.GetKey(KeyCode.Return))
        {
            _dash = _dashSpeed;
        }
        else
        {
            _dash = 1;
        }
    }
}
