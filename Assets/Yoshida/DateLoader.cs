using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateLoader : MonoBehaviour
{
    [SerializeField, Header("�݌v�X�R�A�e�L�X�g")] Text _totalScoreText;
    int _totalScore;
    [SerializeField, Header("�݌v�R�C���e�L�X�g")] Text _totalCoinText;
    int _totalCoin;

    void Start()
    {
        _totalScore = PlayerPrefs.GetInt("Score");
        _totalCoin = PlayerPrefs.GetInt("Coin");

        _totalScoreText.text = ("Score\n" + _totalScore.ToString());

        _totalCoinText.text = ("Coin\n" + _totalScore.ToString());
    }
}
