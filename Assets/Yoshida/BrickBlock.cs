using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : BlockBase
{
    [SerializeField] GameObject _effectPrefab;
    public override void BlockBreak()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
        Destroy(_effectPrefab, 1);
    }
}
