using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  public List<Enemy> currentEnemies;
  public Enemy currentTarget;


  void OnTriggerEnter(Collider collider)
  {
    if (collider.GetComponent<Enemy>() != null)
    {
      Enemy newEnemy = collider.GetComponent<Enemy>();
      newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy);});
      currentEnemies.Add(newEnemy);
      Debug.Log(newEnemy.name);
    }
  }

  void OnTriggerExit(Collider collider)
  {
    if (collider.GetComponent<Enemy>() != null)
    {
      Enemy oldEnemy = collider.GetComponent<Enemy>();
      BookKeeping(oldEnemy);
    }
  }

  void BookKeeping(Enemy enemy)
  {
    currentEnemies.Remove(enemy);
  }
}
