using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("所持コイン数")] int _hasCoin = 0;
    public int HasCoin => _hasCoin;
    int _totalCoin;
    public int TotalCoin => _totalScore;
    [SerializeField, Header("所持コインテキスト格納用")] Text _hasCoinText;

    [SerializeField, Header("所持スコア")] int _hasScore = 0;
    public int HasScore => _hasScore;
    int _totalScore;
    public int TotalScore => _totalScore;
    [SerializeField, Header("所持スコアテキスト格納用")] Text _hasScoreText;

    [SerializeField, Header("リトライボタン")] GameObject _returnButton;
    [SerializeField, Header("タイトルボタン")] GameObject _titleButton;
    [SerializeField, Header("制限時間テキスト格納用")] Text _timeText;
    [SerializeField, Header("制限時間")] float _timeLimit = 300;
    public float TimeLimit => _timeLimit;
    [SerializeField, Header("残り時間スコア反映倍率")] int _timeMagnification = 10;
    int _second;

    [SerializeField, Header("ゴールポストアニメーション")] Animator _goalAnim;

    bool _isGameOver = false;
    public bool IsGameOver => _isGameOver;
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
        if (_isGameOver == false && _isGoal == false)
        {
            _timeLimit -= Time.deltaTime;
            _second = (int)_timeLimit;
            if (_second <= 0)
            {
                GameOver();
            }
        }
        _timeText.text = ("Time\n" + _second.ToString());
        _hasCoinText.text = ("Coin\n" + _hasCoin.ToString());
        _hasScoreText.text = ("Score\n" + _hasScore.ToString());
    }

    /// <summary>スコア加算メソッド</summary>
    /// <param name="addScore">加算するスコア数</param>
    public void AddScore(int addScore)
    {
        _hasScore += addScore;
    }

    public void AddCoin(int addCoin)
    {
        _hasCoin += addCoin;
    }

    /// <summary>ゲームオーバー処理</summary>
    public void GameOver()
    {
        _isGameOver = true;
        _returnButton?.SetActive(true);
        Save();
        print("GameOver");
    }

    /// <summary>ゴール処理</summary>
    public void Goal()
    {
        _isGoal = true;
        _hasScore += _second * _timeMagnification;
        _timeLimit = 0;
        _second = 0;
        _titleButton?.SetActive(true);
        _goalAnim.Play("GoalShot");
        Save();
        print("Goal");
    }

    void Save()
    {
        _totalScore += _hasScore;
        _totalCoin += _hasCoin;

        PlayerPrefs.SetInt("Coin", _totalCoin);
        PlayerPrefs.SetInt("Score", _totalScore);
    }

    public void TitleButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
