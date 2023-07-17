using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IseFlower : ItemBase
{
    public override void GetItem()
    {
        Debug.Log( "アイスマリオになりました");
        Destroy(this.gameObject);
    }
}
