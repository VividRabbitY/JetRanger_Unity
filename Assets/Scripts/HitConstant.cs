using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitConstant
{
    public static float playerHitRadio = 0.25f;
    public static float enemyBaseHitRaidio = 0.8f;

    public static float playerShotRadio = 0.4f+enemyBaseHitRaidio;
    public static Dictionary<EnemyshotType, float> enemyShotHitRadio = new Dictionary<EnemyshotType, float>()
    {
        { EnemyshotType.SmallBall,0.2f+playerHitRadio },
        {EnemyshotType.BigBall,0.4f+playerHitRadio },
        {EnemyshotType.Drop,0.2f+playerHitRadio },
    };



}
