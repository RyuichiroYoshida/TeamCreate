using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("累計コイン数")] int _coin = 0;
    public int Coin => _coin;
    [SerializeField, Header("累計スコア")] int _score = 0;
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

    /// <summary>スコア加算メソッド</summary>
    /// <param name="addScore">加算するスコア数</param>
    public void AddScore(int addScore)
    {
        _score += addScore;
    }

    /// <summary>ゲームオーバー処理</summary>
    public void IsGameOver()
    {

    }

    /// <summary>ゴール処理</summary>
    public void Goal()
    {

    }
}
