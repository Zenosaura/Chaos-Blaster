using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickerM : MonoBehaviour
{
    Vector3 mouseworldPos;

    public place currentPlace;
    public turret currentTurret;

    public trophy currenttrophy;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseworldPos.z = 0f;

            RaycastHit2D ray = Physics2D.Raycast(mouseworldPos, Vector2.zero);

            if (ray.collider != null)
            {
                currentPlace = ray.collider.GetComponent<place>();
                currentTurret = ray.collider.GetComponent<turret>();

                currenttrophy = ray.collider.GetComponent<trophy>();
                if (currentPlace != null) currentPlace.OnClick();
                if (currentTurret != null) currentTurret.OnClick();
                if (currenttrophy != null) currenttrophy.OnClick();

            }
            else
            {
                buyM.Instance.HideButton();
                if(currentTurret != null) currentTurret.HideRange();
                upgradeM.Instance.HideButton();
            }

        }
    }
}
