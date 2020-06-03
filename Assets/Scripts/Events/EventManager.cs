using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static List<BlockBehaviour> blockInvokerList = new List<BlockBehaviour>();
    static List<UnityAction<int>> listenerList = new List<UnityAction<int>>();

    static List<BallBehaviour> ballsInvokerList = new List<BallBehaviour>();
    static List<UnityAction> ballsListenerList = new List<UnityAction>();

    public static void AddInvoker( BlockBehaviour blockScript){
        Debug.Log("EM AddInvoker accessed");
        blockInvokerList.Add(blockScript);
        foreach( UnityAction<int> listen in listenerList ){
            blockScript.AddPointsListener(listen);
        }
    }

    public static void AddListener( UnityAction<int> handler){
        Debug.Log("EM Addlistener accessed");
        listenerList.Add(handler);
        foreach( BlockBehaviour block in blockInvokerList){
            block.AddPointsListener(handler);
        }
    }

    public static void AddBallsInvoker( BallBehaviour ballScript){
        Debug.Log("EM AddInvoker accessed");
        ballsInvokerList.Add(ballScript);
        foreach( UnityAction listen in ballsListenerList ){
            ballScript.AddBallsListener(listen);
        }
    }

    public static void AddBallsListener(UnityAction handler){
        Debug.Log("EM Addlistener accessed");
        ballsListenerList.Add(handler);
        foreach( BallBehaviour ball in ballsInvokerList){
            ball.AddBallsListener(handler);
        }
    }
}
