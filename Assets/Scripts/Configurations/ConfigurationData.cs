using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigValues.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 10 ;
    static float ballAliveTime = 5 ; 
    static int minSpawnTime = 5 ;
    static int maxSpawnTime = 10;
    static int stdBlockPoints = 1 ; 
    static int bonusBlockPoints = 3 ; 
    static int pickupBlockPoints = 2 ;
    static float[] blockProbabilities= {0.25f , 0.25f, 0.25f, 0.25f};
    static int maxBalls = 10;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }
    public float BallAliveTime
    {
        get{ return ballAliveTime ; } 
    }

    public int MinSpawnTime
    {
        get { return minSpawnTime; }    
    }
    public int MaxSpawnTime
    {
        get { return maxSpawnTime; }    
    }
    public int StdBlockPoints
    {
        get { return stdBlockPoints; }    
    }
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }    
    }
    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }    
    }
    public float[] GetBlockProbabilities{
        get{ return blockProbabilities ; }
    }
    public int MaxBalls{
        get{return maxBalls; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null ;
		try{
			input = File.OpenText(Path.Combine(
			Application.streamingAssetsPath, ConfigurationDataFileName));
			
			string names = input.ReadLine();
			string values = input.ReadLine();
			
			SetConfigurationDataFields(values);
		}catch(Exception e){
			
		}finally{
			if( input != null){
				input.Close();
			}
		}
    }

    #endregion
	
	void SetConfigurationDataFields( string csvValues ){
		string[] values = csvValues.Split(',');
		
		paddleMoveUnitsPerSecond = float.Parse(values[0]);
		ballImpulseForce = float.Parse(values[1]);
        ballAliveTime = float.Parse(values[2]);
        minSpawnTime = int.Parse(values[3]);
        maxSpawnTime = int.Parse(values[4]);
        stdBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);

        int j = 8 ; 
        if( float.Parse(values[8]) + float.Parse(values[9]) 
            + float.Parse(values[10]) + float.Parse(values[11])  == 1 ){
                for( int i = 0 ; i < 4 ; i ++){
                    blockProbabilities[i] = float.Parse( values[j]);
                    j++; 
                }
            }
        maxBalls = int.Parse(values[12]);
	}
}
