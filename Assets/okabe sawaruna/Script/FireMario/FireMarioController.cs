using UnityEngine;

public class FireMarioController : PlayerController
{
    [SerializeField] GameObject _fireBallPrefab;
    [SerializeField] GameObject __StandMarioPrefab;
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
    public override void EnemyHit()
    {
        Instantiate(__StandMarioPrefab, transform.position, Quaternion.identity);
        Debug.Log("デフォルトマリオになりました");
        Destroy(this.gameObject);
    }
    private void FixedUpdate()
    {
        _timer++;
    }
}
