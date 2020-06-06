using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    // Add points event
    static List<BlockBehaviour> blockInvokerList = new List<BlockBehaviour>();
    static List<UnityAction<int>> listenerList = new List<UnityAction<int>>();
    // Balls Left event
    static List<BallBehaviour> ballsInvokerList = new List<BallBehaviour>();
    static List<UnityAction> ballsListenerList = new List<UnityAction>();
    // Freeze Effect Event
    static List<PickupBlockBehaviour> pickupBlockInvokerList = new List<PickupBlockBehaviour>();
    static List<UnityAction<float>> pickupListenerList = new List<UnityAction<float>>();
    // Speedup Effect Event
    static List<PickupBlockBehaviour> speedupBlockInvokerList = new List<PickupBlockBehaviour>();
    static List<UnityAction<float , float>> speedupBlockListenerList = new List<UnityAction<float, float>>();

    // Add Points methods 
    public static void AddInvoker( BlockBehaviour blockScript){
        Debug.Log(" Points AddInvoker accessed");
        blockInvokerList.Add(blockScript);
        foreach( UnityAction<int> listen in listenerList ){
            blockScript.AddPointsListener(listen);
        }
    }

    public static void AddListener( UnityAction<int> handler){
        Debug.Log(" Points Addlistener accessed");
        listenerList.Add(handler);
        foreach( BlockBehaviour block in blockInvokerList){
            block.AddPointsListener(handler);
        }
    }
    // Balls Left methods
    public static void AddBallsInvoker( BallBehaviour ballScript){
        Debug.Log(" Balls left AddInvoker accessed");
        ballsInvokerList.Add(ballScript);
        foreach( UnityAction listen in ballsListenerList ){
            ballScript.AddBallsListener(listen);
        }
    }

    public static void AddBallsListener(UnityAction handler){
        Debug.Log(" Balls Left Addlistener accessed");
        ballsListenerList.Add(handler);
        foreach( BallBehaviour ball in ballsInvokerList){
            ball.AddBallsListener(handler);
        }
    }

    // FreezerEffect Activated methods
    public static void AddFreezerEffectInvoker( PickupBlockBehaviour pickupScript){
        Debug.Log(" Freezer AddInvoker accessed");
        pickupBlockInvokerList.Add(pickupScript);
        foreach( UnityAction<float> listen in pickupListenerList ){
            pickupScript.AddFreezerEffectListener(listen);
        }
    }

    public static void AddPickupEffectListener(UnityAction<float> handler){
        Debug.Log(" Freezer Addlistener accessed");
        pickupListenerList.Add(handler);
        foreach( PickupBlockBehaviour pickup in pickupBlockInvokerList ){
            pickup.AddFreezerEffectListener(handler);
        }
    }

    public static void AddSpeedupEffectInvoker( PickupBlockBehaviour pickupScript){
        Debug.Log(" Speedup AddInvoker accessed");
        speedupBlockInvokerList.Add(pickupScript);
        foreach( UnityAction<float , float> listen in speedupBlockListenerList ){
            pickupScript.AddSpeedupEffectListener(listen);
        }
    }

    public static void AddPickupEffectListener(UnityAction<float , float> handler){
        Debug.Log(" Speedup Addlistener accessed");
        speedupBlockListenerList.Add(handler);
        foreach( PickupBlockBehaviour pickup in speedupBlockInvokerList ){
            pickup.AddSpeedupEffectListener(handler);
        }
    }


}
