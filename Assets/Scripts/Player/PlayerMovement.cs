using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed;
    private PlayerController pController;
    private Rigidbody2D rb;
    private int horizontal;
    private int vertical;
    private Vector2 direction;

    public void SetHorizontal(int value) { horizontal = value; }

    public void SetVertical(int value) { vertical = value; }

    void Start()
    {
        pController = this.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        setDirection();
        move();
    }

    private void setDirection()
    {
        if (horizontal == 1 && pController.pCollision.GetCollisionType("Right") ||
                horizontal == -1 && pController.pCollision.GetCollisionType("Left"))
            horizontal = 0;
        if (vertical == 1 && pController.pCollision.GetCollisionType("Up") ||
                vertical == -1 && pController.pCollision.GetCollisionType("Down"))
            vertical = 0;
        direction = new Vector2(horizontal, vertical).normalized;
    }

    private void move()
    {
        if (pController.pTime != null && !pController.pTime.isFastTime)
            transform.Translate(direction * speed * Time.unscaledDeltaTime);
    }
}
