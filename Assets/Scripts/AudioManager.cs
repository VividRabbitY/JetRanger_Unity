using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音声制御
/// </summary>
public class AudioManager : MonoBehaviour
{
    //SE AudioSource
    public AudioSource[] seSources;

    //インスタンス
    public static AudioManager instance;
    public void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 瞬間SE再生
    /// 単発SEに使用
    /// </summary>
    /// <param name="se">指定するSE</param>
    public void PlaySe(SE se)
    {
            seSources[(int)se].Play();
    }
    /// <summary>
    ///ループSE再生
    ///継続しているSEに使用
    /// </summary>
    /// <param name="se"></param>
    public void PlayLoopSE(SE se)
    {
        if (!seSources[(int)se].isPlaying)
        {
        seSources[(int)se].Play();
        }

    }
    /// <summary>
    /// SE停止
    /// </summary>
    /// <param name="se"></param>
    public void StopSe(SE se)
    {
        seSources[(int)se].Stop();
    }
}

//SE
public enum SE
{
    PlayerShoot,//プレイヤー射撃
    PlayerHit,//プレイヤー被弾
    PlayerJet,//ジェットパック
    EnemyShoot,
    EnemyHit,
    EnemyDie,
}
