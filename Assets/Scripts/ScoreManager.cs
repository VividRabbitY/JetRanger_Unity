using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//スコア管理と更新
public  class ScoreManager : MonoBehaviour
{
    int score;
    int highscore;
    public bool isHighScore;
    public TextMeshProUGUI uGUI;
    public static ScoreManager instance;

    public TextMeshProUGUI clear;
    public TextMeshProUGUI gameover;
    public GameObject[] highscoreObj;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
        isHighScore = false;
        uGUI.text = score.ToString();
        clear.text = score.ToString();
        gameover.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int s)
    {
        score += s;
        uGUI.text = score.ToString();
        clear.text = score.ToString();
        gameover.text = score.ToString();
        if (score >= highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            isHighScore = true;
            foreach(var o in highscoreObj)
            {
                o.SetActive(true);
            }
        }
    }

}
