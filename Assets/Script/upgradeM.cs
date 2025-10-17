using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradeM : MonoBehaviour
{
    public static upgradeM Instance;
    public Image upUI;
    public Button Abutton, sellButton;
    public TextMeshProUGUI abuttonName, aButtonMoney, sellText;
    public moneyM moneyM;

    void Awake()
    {
        Instance = this;
    }
    
    public turret currentTurret;
    public void setCurrentTurret(turret t)
    {
        currentTurret = t;
        Abutton.onClick.RemoveAllListeners();
        sellButton.onClick.RemoveAllListeners();
        if (currentTurret.isSlow == false)
        {
            switch (currentTurret.stage)
            {
                case 1:
                    abuttonName.text = "DMG+";
                    aButtonMoney.text = "75";
                    Abutton.onClick.AddListener(TurretA1);
                    break;
                case 2:
                    abuttonName.text = "Range+";
                    aButtonMoney.text = "100";
                    Abutton.onClick.AddListener(TurretA2);
                    break;
                case 3:
                    abuttonName.text = "FireRate+";
                    aButtonMoney.text = "125";
                    Abutton.onClick.AddListener(TurretA3);
                    break;
                default:
                    abuttonName.text = "Maxed";
                    aButtonMoney.text = "";

                    break;

            }
        }
        else if (currentTurret.isSlow == true)
        {
            switch (currentTurret.stage)
            {
                case 1:
                    abuttonName.text = "Duration+";
                    aButtonMoney.text = "75";
                    Abutton.onClick.AddListener(TurretB1);
                    break;
                case 2:
                    abuttonName.text = "Range+";
                    aButtonMoney.text = "100";
                    Abutton.onClick.AddListener(TurretB2);
                    break;
                case 3:
                    abuttonName.text = "Slow+";
                    aButtonMoney.text = "125";
                    Abutton.onClick.AddListener(TurretB3);
                    break;
                default:
                    abuttonName.text = "Maxed";
                    aButtonMoney.text = "";

                    break;
            }
        }
        
        
        
        if(currentTurret.isMoney == true)
        {
            switch (currentTurret.stage)
            {
                case 1:
                    abuttonName.text = "Money-";
                    aButtonMoney.text = "75";
                    Abutton.onClick.AddListener(TurretC1);
                    break;
                case 2:
                    abuttonName.text = "Range+";
                    aButtonMoney.text = "100";
                    Abutton.onClick.AddListener(TurretC2);
                    break;
                case 3:
                    abuttonName.text = "DMG+";
                    aButtonMoney.text = "125";
                    Abutton.onClick.AddListener(TurretC3);
                    break;
                default:
                    abuttonName.text = "Maxed";
                    aButtonMoney.text = "";
                   
                    break;
            }
        }
        sellText.text = GetRefund(currentTurret.stage).ToString();
        sellButton.onClick.AddListener(Sell);

    }

    public void TurretB1()
    {
        if (currentTurret.stage == 1 && moneyM.moneyAmount > 75)
        {
            moneyM.moneyAmount -= 75;
            currentTurret.stage += 1;
            currentTurret.effectDuration += 3;
            setCurrentTurret(currentTurret);
        }
    }

    public void TurretB2()
    {
        if (currentTurret.stage == 2 && moneyM.moneyAmount > 100)
        {
            moneyM.moneyAmount -= 100;
            currentTurret.stage += 1;
            currentTurret.radius *= 1.5f;
            setCurrentTurret(currentTurret);
        }
    }

    public void TurretB3()
    {
        if (currentTurret.stage == 3 && moneyM.moneyAmount > 125)
        {
            moneyM.moneyAmount -= 125;
            currentTurret.stage += 1;
            currentTurret.effectStrength -= 2;
            setCurrentTurret(currentTurret);
        }
    }
    
    public void TurretC1()
    {
        if (currentTurret.stage == 1 && moneyM.moneyAmount > 75)
        {
            moneyM.moneyAmount -= 75;
            currentTurret.stage += 1;
            currentTurret.moneyTru -= 3;
            setCurrentTurret(currentTurret);
        }
    }

    public void TurretC2()
    {
        if (currentTurret.stage == 2 && moneyM.moneyAmount > 100)
        {
            moneyM.moneyAmount -= 100;
            currentTurret.stage += 1;
            currentTurret.radius *= 1.5f;
            setCurrentTurret(currentTurret);
        }
    }

    public void TurretC3()
    {
        if (currentTurret.stage == 3 && moneyM.moneyAmount > 125)
        {
            moneyM.moneyAmount -= 125;
            currentTurret.stage += 1;
            currentTurret.dmg += 15;
            setCurrentTurret(currentTurret);
        }
    }
     public void TurretA1()
    {
        if (currentTurret.stage == 1 && moneyM.moneyAmount > 75)
        {
            moneyM.moneyAmount -= 75;
            currentTurret.stage += 1;
            currentTurret.dmg += 10;
            setCurrentTurret(currentTurret);
        }
    }

    public void TurretA2()
    {
        if (currentTurret.stage == 2 && moneyM.moneyAmount > 100)
        {
            moneyM.moneyAmount -= 100;
            currentTurret.stage += 1;
            currentTurret.radius *= 1.5f;
            setCurrentTurret(currentTurret);
        }
    }
    
    public void TurretA3()
    {
        if (currentTurret.stage == 3 && moneyM.moneyAmount > 125)
        {
            moneyM.moneyAmount -= 125;
            currentTurret.stage += 1;
            currentTurret.fireRate -= 0.5f;
            setCurrentTurret(currentTurret);
        }
    }

    
    public void Sell()
    {
        if (currentTurret != null)
        {
            int refund = GetRefund(currentTurret.stage);
            moneyM.moneyAmount += refund;
            currentTurret.parentPlace.NotOccupied();
            Destroy(currentTurret.gameObject);
        }
        HideButton();

        currentTurret = null;

    }
    int GetRefund(int stage)
    {
        switch (stage)
        {
            case 1: return 25;
            case 2: return 50;
            case 3: return 100;

            default: return 150;
        }
    }




    Vector3 screenPos;
    public void ShowButton(Vector2 pos)
    {
        if(currentTurret.transform.position.y >= 0.55f)
        {
            screenPos = Camera.main.WorldToScreenPoint(pos);
        }
        else
        {
            screenPos = Camera.main.WorldToScreenPoint(pos + new Vector2(0, 0.75f));
        }
        
        
        upUI.transform.position = screenPos;
    }

    public void HideButton()
    {
        upUI.transform.position = new Vector3(-9999, -9999, 0);
    }

}