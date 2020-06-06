using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBalls : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    void Start()
    {
        for( int i = 0 ; i < 5 ; i ++ ){
        GameObject bally = Instantiate( ballPrefab , new Vector2( -2 + i ,0  ) , Quaternion.identity);
        Rigidbody2D rd = bally.GetComponent<Rigidbody2D>();
        float angle = -30 * i  * Mathf.PI / 180;
		Vector2 direction = new Vector2( Mathf.Cos(angle) , Mathf.Sin(angle));
		rd.AddForce( direction * 10 , ForceMode2D.Impulse );
        }     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D( Collision2D col ){
        Debug.Log("MM coll");
    }
}
