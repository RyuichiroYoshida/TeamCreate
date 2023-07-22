using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireMarioController : PlayerController
{
    [SerializeField] GameObject _fireBallPrefab;
    [SerializeField] int _coolTime = 0;
    int _timer = 0;
    

    Transform _muzzle;
    private void Start()
    {
        base.Start();
        _muzzle = transform.Find("Muzzle").gameObject.transform;
    }
    public  override void FireAttack()
    {
        if (_timer > _coolTime)
        {
            Instantiate(_fireBallPrefab, _muzzle.transform.position, Quaternion.identity);
            _timer = 0;
        }
    }
    private void FixedUpdate()
    {
        _timer++;
    }
}
