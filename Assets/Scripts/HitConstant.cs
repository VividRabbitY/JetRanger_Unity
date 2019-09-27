using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//当たり判定関連半径
public static class HitConstant
{
    //プレイヤー
    public static float playerHitRadio = 0.25f;
    //エネミー
    public static float enemyBaseHitRaidio = 0.8f;
    //プレイヤー弾
    public static float playerShotRadio = 0.4f+enemyBaseHitRaidio;
    //エネミー弾
    public static Dictionary<EnemyshotType, float> enemyShotHitRadio = new Dictionary<EnemyshotType, float>()
    {
        { EnemyshotType.SmallBall,0.2f+playerHitRadio },
        {EnemyshotType.BigBall,0.4f+playerHitRadio },
        {EnemyshotType.Drop,0.2f+playerHitRadio },
        { EnemyshotType.Bound,0.2f+playerHitRadio},
    };



}
