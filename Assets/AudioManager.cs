using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] seSources;

    public static AudioManager instance;
    public void Awake()
    {
        instance = this;
    }
    public void PlaySe(SE se)
    {
        if (!seSources[(int)se].isPlaying)
        {
            seSources[(int)se].Play();
                }
    }
}

public enum SE
{
    PlayerShoot,
    PlayerHit,
    EnemyShoot,
    EnemyHit,
    EnemyDie,
}
