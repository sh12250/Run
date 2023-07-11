using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;
    public GameObject gameOverUi;

    private int score = 0;

    private void Awake()
    {
        if(!instance.IsValid())
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두개 이상의 게임 매니져가 존재합니다");
            Destroy(gameObject);
        }

        //List<int> intList = null;
        //Debug.LogFormat("intList가 유효한지? (존재하는지?) : {0}", intList.IsValid());
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
            // == GFunc.LoadScene("PlayScene");
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameOver)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);                  
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
