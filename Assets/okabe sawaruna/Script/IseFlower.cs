using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IseFlower : ItemBase
{
    public override void GetItem()
    {
        Debug.Log( "�A�C�X�}���I�ɂȂ�܂���");
        Destroy(this.gameObject);
    }
}
