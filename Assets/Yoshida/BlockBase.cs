using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockBase : MonoBehaviour
{
    public abstract void BlockBreak();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BlockBreak();
        }
    }
}