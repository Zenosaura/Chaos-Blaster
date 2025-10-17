using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class buyM : MonoBehaviour
{
    public static buyM Instance;
    public Image buyUI;

    public moneyM moneyM;
    public GameObject turretPrefab;
    public GameObject turretSlow;

    public GameObject turretWeak;

    public GameObject turretMoney;
    void Awake()
    {
        Instance = this;
    }

    public place currentPlace;
    public void setCurrentPlace(place p)
    {
        currentPlace = p;
    }
    Vector3 screenPos;
    public void ShowButton(Vector2 pos)
    {
        screenPos = Camera.main.WorldToScreenPoint(pos + new Vector2(0, 0.75f));
        buyUI.transform.position = screenPos;
    }

    public void HideButton()
    {
        buyUI.transform.position = new Vector3(-9999, -9999, 0);
    }


    public void BuyTurret()
    {
        if (moneyM.moneyAmount >= 100)
        {
            GameObject turret1 = Instantiate(turretPrefab, currentPlace.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            turret turretScript = turret1.GetComponent<turret>();
            turretScript.parentPlace = currentPlace;
            turretScript.transform.SetParent(currentPlace.transform, true);
            moneyM.moneyAmount -= 100;

            currentPlace.Occupied();
        }

        HideButton();
    }

    public void BuyTurretBig()
    {
        if (moneyM.moneyAmount >= 50)
        {
            GameObject turret1 = Instantiate(turretWeak, currentPlace.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            turret turretScript = turret1.GetComponent<turret>();
            turretScript.parentPlace = currentPlace;
            turretScript.transform.SetParent(currentPlace.transform, true);
            moneyM.moneyAmount -= 50;

            currentPlace.Occupied();
        }

        HideButton();
    }

    public void BuyTurretMoney()
    {
        if (moneyM.moneyAmount >= 150)
        {
            GameObject turret1 = Instantiate(turretMoney, currentPlace.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            turret turretScript = turret1.GetComponent<turret>();
            turretScript.parentPlace = currentPlace;
            turretScript.transform.SetParent(currentPlace.transform, true);
            moneyM.moneyAmount -= 150;

            currentPlace.Occupied();
        }

        HideButton();
    }


    public void BuyTurretSlow()
    {
        if (moneyM.moneyAmount >= 125)
        {
            GameObject turret1 = Instantiate(turretSlow, currentPlace.transform.position + new Vector3(0, 1f,0), Quaternion.identity);
            turret turretScript = turret1.GetComponent<turret>();
            turretScript.parentPlace = currentPlace;
            turretScript.transform.SetParent(currentPlace.transform, true);
            moneyM.moneyAmount -= 125;

            currentPlace.Occupied();
        }

        HideButton();
    }
}
