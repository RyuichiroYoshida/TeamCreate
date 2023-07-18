using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�݌v�R�C����")] int _coin = 0;
    public int Coin => _coin;
    [SerializeField, Header("�݌v�X�R�A")] int _score = 0;
    public int NowScore => _score;

    float _timer = 0;
    public float Timer => _timer;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
           
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    /// <summary>�X�R�A���Z���\�b�h</summary>
    /// <param name="addScore">���Z����X�R�A��</param>
    public void AddScore(int addScore)
    {
        _score += addScore;
    }

    /// <summary>�Q�[���I�[�o�[����</summary>
    public void IsGameOver()
    {

    }

    /// <summary>�S�[������</summary>
    public void Goal()
    {

    }
}
