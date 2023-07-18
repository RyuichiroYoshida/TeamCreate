using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    float _moveDirection;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̈ʒu�ɂ���Ĕ�ԕ�����ς���
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        if(this.transform.position.x - _player.transform.position.x > 0)
        {
            _moveDirection = 1;
        }
        else
        {
            _moveDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_moveDirection * _moveSpeed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //�����R�E�����G�ɓ����������̏���
            Destroy(collision.gameObject, 2f);//�j��
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;//�����蔻����Ȃ���
            rb.AddForce(10 * Vector2.up, ForceMode2D.Impulse);//��ɕ�������
            rb.constraints = RigidbodyConstraints2D.None;//FreezeRotation�̃`�F�b�N���O��
        }
    }
}
