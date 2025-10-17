using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem : MonoBehaviour
{
    public int health;
    public Collider2D col2;
    public bool isAlive = true;
    public int value;
    public int pointIndex = 0;
    public float moveSpeed;
    public moneyM moneyM;
    public Transform targetPos;

    void Awake()
    {
        moneyM = FindObjectOfType<moneyM>();
    }
    public void TakeDamage(int dmg){
        health -= dmg;
        if (health <= 0) Death();
    }
    public void Death(){
        col2.enabled = false;
        isAlive = false;
        gameObject.SetActive(false);

        
        moneyM.moneyAmount += value;
       
        

    }
}
