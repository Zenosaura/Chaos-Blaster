using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moneyM : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int moneyAmount;


    void Update()
    {
        moneyText.text = moneyAmount.ToString();
    }
}
