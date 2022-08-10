using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField, Range(0f, 0.9f)] private float distance;
    [SerializeField, Range(0f, 0.9f)] private float radius;
    [SerializeField] private LayerMask layer;
    private Dictionary<string, bool> collisionType = new Dictionary<string, bool>(); 

    public bool GetCollisionType(string key) { return collisionType[key]; }


    void Start()
    {
        collisionType.Add("Up", false);
        collisionType.Add("Down", false);
        collisionType.Add("Left", false);
        collisionType.Add("Right", false);
    }

    void Update()
    {
        resetColisionValues();
        shootRay();
    }

    private void resetColisionValues()
    {
        collisionType["Up"] = false;
        collisionType["Down"] = false;
        collisionType["Left"] = false;
        collisionType["Right"] = false;
    }

    private void shootRay()
    {
        for (int i = -1 ; i < 2 ; i++) //Up
            collisionType["Up"] = collisionType["Up"] ||
                Physics2D.Raycast(transform.position + new Vector3(radius * i, radius), Vector2.up, distance, layer);

        for (int i = -1 ; i < 2 ; i++)//Down
            collisionType["Down"] = collisionType["Down"] ||
                Physics2D.Raycast(transform.position + new Vector3(radius * i, -radius), Vector2.down, distance, layer);

        for (int i = -1 ; i < 2 ; i++)//Left
            collisionType["Left"] = collisionType["Left"] ||
                Physics2D.Raycast(transform.position + new Vector3(-radius, radius * i), Vector2.left, distance, layer);

        for (int i = -1 ; i < 2 ; i++) //Right
            collisionType["Right"] = collisionType["Right"] ||
                Physics2D.Raycast(transform.position + new Vector3(radius, radius * i), Vector2.right, distance, layer);
    }
}
