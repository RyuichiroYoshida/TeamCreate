using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�݌v�R�C����")] int _coin = 0;
    public int Coin => _coin;
    [SerializeField, Header("�݌v�X�R�A")] int _score = 0;
    public int AllScore => _score;
    [SerializeField, Header("���g���C�{�^��")] GameObject _returnButton;
    [SerializeField, Header("�^�C�g���{�^��")] GameObject _titleButton;

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

    /// <summary>�X�R�A���Z���\�b�h</summary>
    /// <param name="addScore">���Z����X�R�A��</param>
    public void AddScore(int addScore)
    {
        _score += addScore;
    }

    /// <summary>�Q�[���I�[�o�[����</summary>
    public void IsGameOver()
    {
        _returnButton?.SetActive(true);
        print("GameOver");
    }

    /// <summary>�S�[������</summary>
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
