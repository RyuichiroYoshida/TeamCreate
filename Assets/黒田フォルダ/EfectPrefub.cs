using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectPrefub : MonoBehaviour
{
    [SerializeField] float _lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,_lifeTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
