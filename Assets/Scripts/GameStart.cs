using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameStart : MonoBehaviour
{
    Scene gameScene;
    PlayableDirector pd;
    bool canStart;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        timer = 0.0f;
        canStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        canStart = true;
    }
    public void Startgame()
    {
        if(canStart&& pd.state!=PlayState.Playing)
       pd.Play();
    }
}
