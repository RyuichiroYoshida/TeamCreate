using UnityEngine;

public class FireFlower : ItemBase
{
    [SerializeField] GameObject _fireMarioPrefab;
    public override void GetItem()
    {
        
        Instantiate(_fireMarioPrefab, transform.position, Quaternion.identity);
        Debug.Log("�t�@�C�A�[�}���I�ɂȂ�܂���");
        Destroy(this.gameObject);
        Destroy(_mario);
    }
}
