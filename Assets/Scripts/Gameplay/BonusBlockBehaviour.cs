using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockBehaviour : BlockBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        blockPoints = ConfigurationUtils.BonusBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
