using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Human
{
    // Start is called before the first frame update
    void Start()
    {
        Consume();
        TakeRest();
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("attacking . . .");
    }
}
