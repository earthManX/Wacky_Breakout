using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlockBehaviour : BlockBehaviour
{
    [SerializeField]
    Sprite[] pickupSprites = new Sprite[2];

    PickupEffect pickupEffect;
    
    public PickupEffect Effect{
        get{ return pickupEffect; }

        set{ 
        pickupEffect = value ; 
        GetComponent<SpriteRenderer>().sprite = pickupSprites[(int)pickupEffect];
        }
    }
    void Start()
    {
        base.Start();
        blockPoints = ConfigurationUtils.PickupBlockPoints;
    }

    
}
