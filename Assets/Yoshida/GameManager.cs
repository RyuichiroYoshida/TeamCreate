using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("累計コイン数")] int _coin = 0;
    public int Coin => _coin;
    [SerializeField, Header("累計スコア")] int _score = 0;
    public int AllScore => _score;
    [SerializeField, Header("リトライボタン")] GameObject _returnButton;
    [SerializeField, Header("タイトルボタン")] GameObject _titleButton;

    float _timer = 0;
    public float Timer => _timer;
    bool _isGoal = false;
    public bool IsGoal => _isGoal;

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
        _returnButton?.SetActive(false);
        _titleButton?.SetActive(false);
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
        _returnButton?.SetActive(true);
        print("GameOver");
    }

    /// <summary>ゴール処理</summary>
    public void Goal()
    {
        _titleButton?.SetActive(true);
        print("Goal");
    }

    public void TitleButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
