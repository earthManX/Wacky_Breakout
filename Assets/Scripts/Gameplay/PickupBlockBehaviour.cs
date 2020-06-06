using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlockBehaviour : BlockBehaviour
{
    [SerializeField]
    Sprite[] pickupSprites = new Sprite[2];

    PickupEffect pickupEffect;
    
    float freezerEffectDuration;
    FreezerEffectEvent freezerEffectEvent ;

    float speedupEffectDuration;
    float speedupFactor;
    SpeedupEffectEvent speedupEffectEvent;

    public PickupEffect Effect{
        get{ return pickupEffect; }

        set{ 
        pickupEffect = value ;
        GetComponent<SpriteRenderer>().sprite = pickupSprites[(int)pickupEffect];

        if( pickupEffect == PickupEffect.Freezer ){ 
        
            freezerEffectEvent = new FreezerEffectEvent();
            freezerEffectDuration = ConfigurationUtils.FreezerEffectDuration;
            EventManager.AddFreezerEffectInvoker(this);
        
        }else if( pickupEffect == PickupEffect.Speedup ){
            
            speedupEffectEvent = new SpeedupEffectEvent();
            speedupEffectDuration = ConfigurationUtils.SpeedupEffectDuration;
            speedupFactor = ConfigurationUtils.SpeedupFactor;
            EventManager.AddSpeedupEffectInvoker(this);
        }
        }
    }
    void Start()
    {
        base.Start();
        blockPoints = ConfigurationUtils.PickupBlockPoints;
    }

    public void AddFreezerEffectListener( UnityAction<float> listener){
        freezerEffectEvent.AddListener( listener );
    }

    public void AddSpeedupEffectListener( UnityAction< float, float > listener){
        speedupEffectEvent.AddListener( listener );
    }

    override protected void OnCollisionEnter2D( Collision2D coll ){
        if( pickupEffect == PickupEffect.Freezer ){
            freezerEffectEvent.Invoke(freezerEffectDuration);
        }else if( pickupEffect == PickupEffect.Speedup){
            speedupEffectEvent.Invoke(speedupEffectDuration , speedupFactor);
        }
        base.OnCollisionEnter2D( coll );
    }

    
}
