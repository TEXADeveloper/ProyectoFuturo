using UnityEngine;
using System.Collections.Generic;

public class TimeArea : MonoBehaviour
{
    [HideInInspector] public float TimeMultiplier;
    private List<move> enemiesInArea = new List<move>();
    private bool showTimeArea = false;

    public List<move> GetEnemiesList()
    {
        return enemiesInArea;
    }

    void Update()
    {
        SetEnemiesMultipliers();
    }

    private void SetEnemiesMultipliers()
    {
        foreach (move enemy in enemiesInArea)
            enemy.SetMultiplier(TimeMultiplier);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        move colMove = col.gameObject.GetComponent<move>();
        if (colMove != null)
            enemiesInArea.Add(colMove);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        move colMove = col.gameObject.GetComponent<move>();
        if (colMove != null)
        {
            RemoveMultiplier();
            enemiesInArea.Remove(colMove);
        }
    }

    private void RemoveMultiplier()
    {
        foreach (move enemy in enemiesInArea)
            enemy.SetMultiplier(1);
    }

    void OnDisable()
    {
        RemoveMultiplier();
        enemiesInArea.Clear();
    }
}
