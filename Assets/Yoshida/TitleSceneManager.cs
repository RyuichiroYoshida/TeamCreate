using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] GameObject _fade;
    void Start()
    {
        _fade.SetActive(false);
    }

    public void StartButtonClick()
    {
        _fade.SetActive(true);
        print("Start");
    }

    public void FadeOut()
    {
        SceneManager.LoadScene(1);
    }
}
