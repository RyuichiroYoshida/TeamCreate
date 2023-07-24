using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�����R�C����")] int _hasCoin = 0;
    public int HasCoin => _hasCoin;
    int _totalCoin;
    public int TotalCoin => _totalScore;
    [SerializeField, Header("�����R�C���e�L�X�g�i�[�p")] Text _hasCoinText;

    [SerializeField, Header("�����X�R�A")] int _hasScore = 0;
    public int HasScore => _hasScore;
    int _totalScore;
    public int TotalScore => _totalScore;
    [SerializeField, Header("�����X�R�A�e�L�X�g�i�[�p")] Text _hasScoreText;

    [SerializeField, Header("���g���C�{�^��")] GameObject _returnButton;
    [SerializeField, Header("�^�C�g���{�^��")] GameObject _titleButton;
    [SerializeField, Header("�������ԃe�L�X�g�i�[�p")] Text _timeText;
    [SerializeField, Header("��������")] float _timeLimit = 300;
    public float TimeLimit => _timeLimit;
    [SerializeField, Header("�c�莞�ԃX�R�A���f�{��")] int _timeMagnification = 10;
    int _second;

    [SerializeField, Header("�S�[���|�X�g�A�j���[�V����")] Animator _goalAnim;

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

    /// <summary>�X�R�A���Z���\�b�h</summary>
    /// <param name="addScore">���Z����X�R�A��</param>
    public void AddScore(int addScore)
    {
        _hasScore += addScore;
    }

    public void AddCoin(int addCoin)
    {
        _hasCoin += addCoin;
    }

    /// <summary>�Q�[���I�[�o�[����</summary>
    public void GameOver()
    {
        _isGameOver = true;
        _returnButton?.SetActive(true);
        Save();
        print("GameOver");
    }

    /// <summary>�S�[������</summary>
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
