using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLIfe : MonoBehaviour
{
    [SerializeField, Header("�p�[�e�B�N���\������")] float _particleLife = 1;
    void Start()
    {
        Destroy(gameObject, _particleLife);
    }
}
