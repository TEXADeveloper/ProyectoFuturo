using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField, Range(0f, 0.9f)] private float distance;
    [SerializeField] private LayerMask layer;
    bool collisioned;

    void Update()
    {
        collisioned = ShootRay();
        Debug.Log(collisioned);
    }

    bool ShootRay()
    {
        bool shoots = false;
        for (int i = -1 ; i < 2 ; i++) //Up
            shoots = shoots || Physics2D.Raycast(transform.position + new Vector3(0.5f * i, 0.5f), Vector2.up, distance, layer);

        for (int i = -1 ; i < 2 ; i++)//Down
            shoots = shoots || Physics2D.Raycast(transform.position + new Vector3(0.5f * i, -0.5f), Vector2.down, distance, layer);

        for (int i = -1 ; i < 2 ; i++)//Left
            shoots = shoots || Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.5f * i), Vector2.left, distance, layer);

        for (int i = -1 ; i < 2 ; i++) //Right
            shoots = shoots || Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f * i), Vector2.right, distance, layer);
        
        return shoots;
    }

    /*
    
    (-0.5, 0.5f) -> Vector3.up, Vector3.left
    (0.5, 0.5f) -> Vector3.up, Vector3.right
    (-0.5, -0.5f) -> Vector3.down, Vector3.left
    (0.5, -0.5f) -> Vector3.down, Vector3.right
    
    (0, 0.5f) -> Vector3.up
    (0, -0.5f) -> Vector3.down
    (-0.5, 0) -> Vector3.left
    (0.5, 0) -> Vector3.right

    |¯¯¯¯¯¯¯|
    |       |
    |_______|

    */
}
