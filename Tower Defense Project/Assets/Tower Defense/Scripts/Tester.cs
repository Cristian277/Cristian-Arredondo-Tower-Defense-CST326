using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Purse purse;
    
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
        Camera.main.transform.position.z));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
          if (hit.transform.tag == "Enemy")
          {
                    if (!hit.transform.GetComponent<Enemy>().Damage())
                    {
                        purse.increaseCoinCount();
                    }
          }
      }
    }
}
