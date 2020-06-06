using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	static ConfigurationData configurationData;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond{
        get { return configurationData.PaddleMoveUnitsPerSecond ; }
    }
	public static float BallImpulseForce{
		get{ return configurationData.BallImpulseForce ; }
	}
    public static float BallAliveTime{
        get{ return configurationData.BallAliveTime; }
    }
    public static int MinSpawnTime{
        get{ return configurationData.MinSpawnTime; }
    }
    public static int MaxSpawnTime{
        get{ return configurationData.MaxSpawnTime ; }
    }
    public static int StdBlockPoints{
        get{ return configurationData.StdBlockPoints ; }
    }
    public static int BonusBlockPoints{
        get{ return configurationData.BonusBlockPoints ; }
    }
    public static int PickupBlockPoints{
        get{ return configurationData.PickupBlockPoints ; }
    }
    public static float[] GetBlockProbabilities{
        get{ return configurationData.GetBlockProbabilities; }
    }
    public static int MaxBalls{
        get{ return configurationData.MaxBalls; }
    }
    public static float FreezerEffectDuration{
        get{ return configurationData.FreezerEffectDuration ; }
    }
    public static float SpeedupEffectDuration{
        get{ return configurationData.SpeedupEffectDuration ;}
    }
    public static float SpeedupFactor{
        get{ return configurationData.SpeedupFactor; }
    }
    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
		configurationData = new ConfigurationData();
		//Debug.Log( configurationData.PaddleMoveUnitsPerSecond);
		//Debug.Log(configurationData.BallImpulseForce);
    }
}
