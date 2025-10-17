using System.Collections;
using System.Collections.Generic;


using TMPro;
using UnityEngine;

public class detectDeath : MonoBehaviour
{
    public int count = 0;
    public int maxIn = 5;
    public int countReverse;
    public GameObject gameOverScreen;

    void Start()
    {
        countReverse = maxIn;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy")){
            count++;
            countReverse--;

            StartCoroutine(ChangeSprite());
            Debug.Log("ENEMY IN");
            Destroy(collision.gameObject);
        }
        
    }
    public GameObject Heart;
    
    public Sprite heart1;
    public Sprite heart2;

    IEnumerator ChangeSprite()
    {
        SpriteRenderer sr = Heart.GetComponent<SpriteRenderer>();
        sr.sprite = heart2;

        yield return new WaitForSeconds(0.1f);

        sr.sprite = heart1;
    }

public TextMeshProUGUI heartText;
    void Update()
    {
        heartText.text = countReverse.ToString();
        
        if(count >= maxIn)
        {
            gameOverScreen.SetActive(true);
            
        }
    }
}
