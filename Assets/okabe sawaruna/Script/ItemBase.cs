using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    //移動速度
    [SerializeField] float _moveSpeed = 1f;
    //lineのオフセット
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    //壁のレイヤー
    [SerializeField] LayerMask _wallLayer = 0;
    //移動方向
    Vector2 _moveDirection = Vector2.right;
    Rigidbody2D _rb = default;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveWithTurn();
    }

    private void MoveWithTurn()
    {
        Vector2 start = this.transform.position = _rb.position;
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;    //veroは速度ベクトル
        if (_moveDirection == Vector2.right)
        {
            Debug.DrawLine(start, start + _lineForWall);
            hit = Physics2D.Linecast(start,start + _lineForWall, _wallLayer);
        }
        else
        {
            Debug.DrawLine(start,start - _lineForWall);
            hit = Physics2D.Linecast(start, start - _lineForWall, _wallLayer);
        }
        if (hit.collider)
        {
            Debug.Log("Hit Wall");
                if(_moveDirection == Vector2.right)
            {
                _moveDirection = Vector2.left;
            }
                else if (_moveDirection == Vector2.left)
            {
                _moveDirection = Vector2.right;
            }
        }
        velo = _moveDirection.normalized * _moveSpeed;
        velo.y =_rb.velocity.y;
        _rb.velocity = velo;
    }
    public abstract void GetItem();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
           GetItem();
        }
    }
 }
