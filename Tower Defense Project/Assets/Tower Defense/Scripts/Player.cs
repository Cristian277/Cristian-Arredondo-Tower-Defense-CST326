using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Enemy [] enemies;
    public Purse playerPurse;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                    if (hit.collider.gameObject.name == "BigBadGuy")
                    {
                        enemies[0].decreaseEnemyHealth();
                    }
                    else if (hit.collider.gameObject.name == "SmallBadGuy")
                    {
                        enemies[1].decreaseEnemyHealth();
                    }
                }
               
            }
        }
    }
