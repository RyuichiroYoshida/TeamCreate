using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _stompPrefub;

    public GameObject stompPrefub { get { return _stompPrefub; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Stomp();

        }
    }

    public virtual void Stomp()
    {
        Instantiate(_stompPrefub, this.transform.position, _stompPrefub.transform.rotation);
        Destroy(this.gameObject);
    }
}
