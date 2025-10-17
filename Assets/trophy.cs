using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trophy : MonoBehaviour
{
    public GameObject WinScreen;
    public void OnClick()
    {
        WinScreen.SetActive(true);
    }
}
