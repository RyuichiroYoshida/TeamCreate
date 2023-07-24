using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLIfe : MonoBehaviour
{
    [SerializeField, Header("パーティクル表示時間")] float _particleLife = 1;
    void Start()
    {
        Destroy(gameObject, _particleLife);
    }
}
