using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlockBehaviour : BlockBehaviour
{   
    [SerializeField]
    List<Sprite> stdBlockPrefabs = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        blockPoints = ConfigurationUtils.StdBlockPoints;
       // SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = stdBlockPrefabs[ Random.Range(0, stdBlockPrefabs.Count  ) ] ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
