using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public int coinWorth;
  public float health;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;
  public Purse purse;

    void Start()
    {
        myPathThroughLife = route.path;
        transform.position = myPathThroughLife[index].transform.position;
        Recalculate();

        if (this.gameObject.name == "BigBadGuy")
        {
            health = 50;
        }else if(this.gameObject.name == "SmallBadGuy")
        {
            health = 20;
        }
    }

    void Update()
  {
    if (!stop)
    {
      if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }

      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }
    }

  void Recalculate()
  {
    if (index < myPathThroughLife.Length -1)
    {
      nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

    }
    else
    {
      stop = true;
    }
  }

    public void decreaseEnemyHealth()
    {
        health -= 10;
        Debug.Log("Enemy is at " + health + " health");
        if (health <= 0)
        {
            Debug.Log("Enemy has been killed!");
            Destroy(this.gameObject);
            purse.increaseCoinCount();
        }
    }
}
