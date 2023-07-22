using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    Vector2 _moveDirection = new Vector2(0,0);
    GameObject _player;

    [SerializeField] GameObject _stompPrefub;
    int _moveTimer;

    [SerializeField] LayerMask _wallLayer;
    [SerializeField]bool _dead = false;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̈ʒu�ɂ���Ĕ�ԕ�����ς���
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        if(this.transform.position.x - _player.transform.position.x > 0)
        {
            _moveDirection.x = 0.6f;
        }
        else
        {
            _moveDirection.x = -0.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���g���ǂɓ����������A�������ŏ�����
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _moveDirection);


            RaycastHit2D hitWall = Physics2D.Linecast(start, start + _moveDirection, _wallLayer);
        if (hitWall)
        {
            _moveDirection *= -1;
            
        }

            _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rb.velocity.y);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //�����R�E�����G�ɓ����������̏���
            Destroy(collision.gameObject, 1f);//�j��
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            if (collision.gameObject.GetComponent<CircleCollider2D>() != null)
            {
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;//��а�̓����蔻����Ȃ���
            }
            else if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;//��а�̓����蔻����Ȃ���
            }

            rb.AddForce(10 * Vector2.up, ForceMode2D.Impulse);//��ɕ�������
            rb.constraints = RigidbodyConstraints2D.None;//FreezeRotation�̃`�F�b�N���O��
        }
    }

    private void FixedUpdate()
    {
        _moveTimer++;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _moveTimer > 20)
        {
            Instantiate(_stompPrefub, this.transform.position, _stompPrefub.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
