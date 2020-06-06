using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
	static SpeedEffectMonitor sp;
    #region Properties
    
    public static float TimeLeft{
        get{ return sp.TimeLeft  ; }
    }
    public static float SpeedFactor{
        get { return sp.SpeedFactor ;}
    }
    public static bool IsSpeedup{
        get { return sp.IsSpeedup ; }
    }
    #endregion
    public static void Initialize()
    {
		sp = new SpeedEffectMonitor();
		//Debug.Log( configurationData.PaddleMoveUnitsPerSecond);
		//Debug.Log(configurationData.BallImpulseForce);
    }
}
