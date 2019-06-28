using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class ScoreManager : MonoBehaviour
{
    int score;
    public TextMeshProUGUI uGUI;
    public static ScoreManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
        uGUI.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int s)
    {
        score += s;
        uGUI.text = score.ToString();
    }

}
