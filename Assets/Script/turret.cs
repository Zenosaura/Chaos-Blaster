using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class turret : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        moneyM = FindObjectOfType<moneyM>();
    }

    public bool isSlow;
    moneyM moneyM;    
    public bool isMoney;
    public place parentPlace;
    public float radius;
    public LayerMask layerMask;
    public GameObject bulletPrefab;

    public GameObject range;

    public Transform rangeTransform;
    public enem target;
    // Update is called once per frame
    void Update()
    {
        Detect();
    }
    GameObject currentRange;

    public int stage = 0;
    public void OnClick()
    {
        //upgrade Ui
        upgradeM.Instance.setCurrentTurret(this);
        upgradeM.Instance.ShowButton(transform.position);

        currentRange = Instantiate(range, rangeTransform.position, Quaternion.identity);
        currentRange.transform.localScale = new Vector3(2 * radius, 2 * radius, 1);
        currentRange.transform.SetParent(rangeTransform, true);
    }

    public void HideRange()
    {
        Destroy(currentRange.gameObject);
    }
    public GameObject firePoint;
    public List<enem> enemiesInRange = new List<enem>();


    public float fireRate = 1;

    public int dmg;
    public float shootSpeed;
   public  bool isShooting = false;
    void Detect()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        enemiesInRange.Clear();
        foreach (Collider2D hit in hits)
        {
            enem enemy = hit.GetComponent<enem>();
            if (enemy != null && enemy.isAlive) enemiesInRange.Add(enemy);
        }

        if (target == null || !target.isAlive || !enemiesInRange.Contains(target))
        {
            if (enemiesInRange.Count > 0)
            {
                target = enemiesInRange[0];
            }
            else target = null;
        }

        if (target != null && !isShooting) StartCoroutine(Shooting());
    }


    IEnumerator Shooting()
    {
        isShooting = true;
        while (true)
        {

            if (target == null || !target.isAlive)
            {
                foreach (enem enm in enemiesInRange)
                {
                    target = enm;
                    break;
                }
                if (target == null)
                {
                    isShooting = false;
                    yield break;
                }
            }

            GameObject bullet1 = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet bulletscript = bullet1.GetComponent<bullet>();

            bulletscript.dmg = dmg;
            bulletscript.shootSpeed = shootSpeed;
            bulletscript.setTarget(target);






            if (isSlow)
            {
                StartCoroutine(Slowing());
            }


            if(isMoney){
                MoneyGun();
            }
            yield return new WaitForSeconds(fireRate);
        }

    }
    public int effectDuration;
    public int effectStrength;

    public int moneyTru;

    IEnumerator Slowing()
    {
        if (target != null) target.moveSpeed = effectStrength;

        yield return new WaitForSeconds(effectDuration);
    }


    void MoneyGun()
    {
        moneyM.moneyAmount -= moneyTru;
        
    }
}
