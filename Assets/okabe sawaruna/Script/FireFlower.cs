using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlower : ItemBase
{
    public override void GetItem()
    {
        Debug.Log("ファイアーマリオになりました");
        Destroy(this.gameObject);
    }
}
