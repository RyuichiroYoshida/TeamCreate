using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatenaBlock : BlockBase
{
    [SerializeField] GameObject _item;
    [SerializeField] GameObject _nullBlock;

    public override void BlockBreak()
    {
        Instantiate(_item, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        Instantiate(_nullBlock, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        Destroy(gameObject);
    }
}
