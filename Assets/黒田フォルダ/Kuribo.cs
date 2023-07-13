using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Kuribo : EnemyBase
{
    [SerializeField] GameObject _kuroboDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PlayerAttack()
    {
        Instantiate(_kuroboDead, this.transform.position, _kuroboDead.transform.rotation);
        Destroy(this.gameObject);
    }
    public override void Stomp()
    {
        Instantiate(_kuroboDead, this.transform.position, _kuroboDead.transform.rotation);
        Destroy(this.gameObject);
    }

}
