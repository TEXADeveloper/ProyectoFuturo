using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed;
    private PlayerController pController;
    private Rigidbody2D rb;
    private int horizontal;
    private int horizontalInput;
    private int vertical;
    private int verticalInput;
    private Vector2 direction;

    public void SetHorizontal(int value) { horizontalInput = value; }

    public void SetVertical(int value) { verticalInput = value; }

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
        if (horizontalInput == 1 && pController.pCollision.GetCollisionType("Right") ||
                horizontalInput == -1 && pController.pCollision.GetCollisionType("Left"))
            horizontal = 0;
        else
            horizontal = horizontalInput;
        if (verticalInput == 1 && pController.pCollision.GetCollisionType("Up") ||
                verticalInput == -1 && pController.pCollision.GetCollisionType("Down"))
            vertical = 0;
        else
            vertical = verticalInput;
        
        direction = new Vector2(horizontal, vertical).normalized;
    }

    private void move()
    {
        if (pController.pTime != null && !pController.pTime.isFastTime)
            transform.Translate(direction * speed * Time.unscaledDeltaTime);
    }
}
