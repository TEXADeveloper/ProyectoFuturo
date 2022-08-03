using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public EnemyAI eAI;
    [HideInInspector] public EnemyMovement eMovement;
    [HideInInspector] public EnemyCollision eCollision;
    [HideInInspector] public EntityLifeTime eLifeTime;

    void Start()
    {
        eAI = this.GetComponent<EnemyAI>();
        eMovement = this.GetComponent<EnemyMovement>();
        eCollision = this.GetComponent<EnemyCollision>();
        eLifeTime = this.GetComponent<EntityLifeTime>();
    }
}
