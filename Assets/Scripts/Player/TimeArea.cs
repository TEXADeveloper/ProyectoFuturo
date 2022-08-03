using UnityEngine;
using System.Collections.Generic;

public class TimeArea : MonoBehaviour
{
    [HideInInspector] public float TimeMultiplier;
    private List<EnemyMovement> enemiesInArea = new List<EnemyMovement>();

    void Update()
    {
        SetEnemiesMultipliers();
    }

    private void SetEnemiesMultipliers()
    {
        foreach (EnemyMovement enemy in enemiesInArea)
            enemy.SetMultiplier(TimeMultiplier);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyMovement colMovement = col.gameObject.GetComponent<EnemyMovement>();
        if (colMovement != null)
            enemiesInArea.Add(colMovement);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        EnemyMovement colMovement = col.gameObject.GetComponent<EnemyMovement>();
        if (colMovement != null)
        {
            RemoveMultiplier();
            enemiesInArea.Remove(colMovement);
        }
    }

    private void RemoveMultiplier()
    {
        foreach (EnemyMovement enemy in enemiesInArea)
            enemy.SetMultiplier(1);
    }

    void OnDisable()
    {
        RemoveMultiplier();
        enemiesInArea.Clear();
    }
}
