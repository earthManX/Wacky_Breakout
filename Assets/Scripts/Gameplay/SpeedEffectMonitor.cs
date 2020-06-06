using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffectMonitor : MonoBehaviour
{
    
    Timer speedupEffectTimer;
    float timeLeft = 0 ;
    float speedFactor = 1.0f ;
    bool isSpeedup = false ; 
    // Start is called before the first frame update

    # region Properties
    public float TimeLeft{
        get{ return timeLeft ; }
    }
    public float SpeedFactor{
        get { return speedFactor ;}
    }
    public bool IsSpeedup{
        get { return isSpeedup ; }
    }
    #endregion

    void Start(){
        speedupEffectTimer = new Timer();
        EventManager.AddPickupEffectListener(MonitorListener);
    }

    void Update(){
        
        if( speedupEffectTimer.Running ){
            timeLeft = speedupEffectTimer.SecondsLeft;
            
        }else{
            timeLeft = 0 ; 
            isSpeedup = false;
        }
    }

    void MonitorListener( float duration , float factor){
        if( timeLeft > 0  ){
            timeLeft += duration;
        }else{
            speedupEffectTimer.Duration = duration;
            speedupEffectTimer.Run();
        }
        isSpeedup = false ;
    }

}
