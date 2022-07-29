using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] float speed;
    private Rigidbody2D rb;
    private int horizontal;
    private int vertical;
    private Vector2 direction;

    public void SetHorizontal(int value) { horizontal = value; }

    public void SetVertical(int value) { vertical = value; }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        setDirection();
        move();
    }

    private void setDirection()
    {
        direction = new Vector2(horizontal, vertical).normalized;
    }

    private void move()
    {
        rb.velocity = direction * speed;
    }
}
