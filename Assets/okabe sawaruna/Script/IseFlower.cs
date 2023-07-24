using UnityEngine;

public class IseFlower : ItemBase
{
    public override void GetItem()
    {
        Debug.Log( "アイスマリオになりました");
        Destroy(this.gameObject);
    }
}
