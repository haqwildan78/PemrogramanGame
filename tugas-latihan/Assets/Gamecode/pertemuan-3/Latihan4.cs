using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan4 : MonoBehaviour
{
    Character Player1;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = new Character("Aethelred", 100, 30);
        Debug.Log($"Name: {Player1.Name}, Health: {Player1.Health}, Damage: {Player1.Damage}");
        Player1.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Character
{
    // PROPERTIES
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    // CONSTRUCTOR
    public Character(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    // METHODS
    public void MoveLeft()
    {
        Debug.Log("moving to left . . .");
    }
    public void MoveRight()
    {
        Debug.Log("moving to right . . .");
    }
    public void Jump ()
    {
        Debug.Log("jumping . . .");
    }
    public void Attack()
    {
        Debug.Log("attacking . . .");
    }
}