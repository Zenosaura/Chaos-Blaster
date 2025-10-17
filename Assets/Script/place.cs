using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class place : MonoBehaviour
{
    public Collider2D collider2;
    public SpriteRenderer spriteRenderer;

    public Sprite sprite;
    public bool isOccupied;
    public void OnClick()
    {
        if (isOccupied) return;

        buyM.Instance.setCurrentPlace(this);
        buyM.Instance.ShowButton(transform.position);
    }
    public void Occupied()
    {
        spriteRenderer.sprite = null;
        collider2.enabled = false;
        isOccupied = true;
    }

    public void NotOccupied()
    {
        spriteRenderer.sprite = sprite;
        collider2.enabled = true;
        isOccupied = false;
    }
}
