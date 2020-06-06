using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockBehaviour : MonoBehaviour
{
    protected int blockPoints  ;
    AddPointsEvent addPointsEvent = new AddPointsEvent();
    // Start is called before the first frame update
    protected void Start()
    {
        EventManager.AddInvoker(this);
    }

	virtual protected void OnCollisionEnter2D( Collision2D coll){
		if( coll.gameObject.CompareTag("Ball")){
            addPointsEvent.Invoke(blockPoints);
            Debug.Log("Parent OnCollision method accessed");
			Destroy(gameObject);
		}
	}

    public void AddPointsListener(UnityAction<int> listener){
        addPointsEvent.AddListener( listener );
        Debug.Log("Parent AddListener accessed");
    }
}
