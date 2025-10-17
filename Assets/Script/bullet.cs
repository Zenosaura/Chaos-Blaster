using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public enem enemy;

    Vector2 targetPos;
    Vector2 fireDirection;

    public float shootSpeed;

    public int dmg;
    void Update()
    {
        transform.position += (Vector3)(fireDirection * shootSpeed * Time.deltaTime);
    }
    public void setTarget(enem enemyTarget)
    {
        enemy = enemyTarget;
        targetPos = enemy.targetPos.transform.position;

        fireDirection = (targetPos - (Vector2)(transform.position)).normalized;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        enem enemy = collision.GetComponent<enem>();

        if(enemy != null)
        {
            enemy.TakeDamage(dmg);

            Destroy(gameObject);
        }
    }
}
