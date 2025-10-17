using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathM : MonoBehaviour
{
    
    public Transform[] points;
  public Transform pathParent;

  public Collider2D holder;
  public List<enem> enemies = new List<enem>();

  public GameObject trophy;

  public spawner spawner;
    void Start(){
      StartCoroutine(Check());
    }

  void Awake()
  {
    points = new Transform[pathParent.childCount];
    for (int i = 0; i < pathParent.childCount; i++)
    {
      points[i] = pathParent.GetChild(i);
    }
  }
    
  

    IEnumerator Check(){
        while (true)
          {
            enemies.Clear();
            foreach (enem enm in FindObjectsOfType<enem>()){
                if(enm != null) enemies.Add(enm);
            }

          yield return new WaitForSeconds(1);

        }
    }

    void Update(){
       if(spawner.WaveCounter >= 15)
        {
            if(enemies.Count == 0)
            {
               holder.enabled = true;
              trophy.SetActive(true);
               
            }
        }

      foreach (enem enm in enemies){
        if(enm.pointIndex < points.Length){
          if(enm != null)
                {
                     enm.transform.position = Vector2.MoveTowards(enm.transform.position, points[enm.pointIndex].transform.position, enm.moveSpeed * Time.deltaTime);

                    if (Vector2.Distance(enm.transform.position, points[enm.pointIndex].transform.position) < 0.1f)
                    {
                       enm.pointIndex += 1;
                    }
          
                }
        }
      }
    }

    


    
}
