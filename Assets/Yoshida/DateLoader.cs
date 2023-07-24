using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateLoader : MonoBehaviour
{
    [SerializeField, Header("累計スコアテキスト")] Text _totalScoreText;
    int _totalScore;
    [SerializeField, Header("累計コインテキスト")] Text _totalCoinText;
    int _totalCoin;

    void Start()
    {
        _totalScore = PlayerPrefs.GetInt("Score");
        _totalCoin = PlayerPrefs.GetInt("Coin");

        _totalScoreText.text = ("Score\n" + _totalScore.ToString());

        _totalCoinText.text = ("Coin\n" + _totalScore.ToString());
    }
}
