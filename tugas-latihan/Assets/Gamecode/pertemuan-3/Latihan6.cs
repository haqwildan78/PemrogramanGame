using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan6 : MonoBehaviour
{
    public int[] IntegerArray;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Write each content in the array");
        foreach (int a in IntegerArray)
        {
            Debug.Log(a);
        }
        Debug.Log($"Index 2 of the array is {IntegerArray[2]}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
