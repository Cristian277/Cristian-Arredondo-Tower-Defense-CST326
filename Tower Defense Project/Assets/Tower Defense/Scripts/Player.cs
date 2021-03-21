using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
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
                    Debug.Log("Big Bad guy Hit");
                }
                else if (hit.collider.gameObject.name == "SmallBadGuy")
                {
                    Debug.Log("Small Bad guy Hit");
                }
            }
        }
    }
}
