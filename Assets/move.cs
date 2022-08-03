using System.Net.Sockets;
using UnityEngine;

public class move : MonoBehaviour
{
    public LayerMask layer;
    private float timeMultiplier = 1;
    int direction = 1;

    public void SetMultiplier(float value)
    {
        timeMultiplier = value;
    }
    
    void Update()
    {
        bool collisionRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.5f, layer);
        bool collisionLeft = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.5f, layer);
        if (collisionLeft)
            direction = 1;
        if (collisionRight)
            direction = -1;





        transform.Translate(new Vector3(5f * direction * Time.deltaTime * timeMultiplier, 0, 0));
    }
}
