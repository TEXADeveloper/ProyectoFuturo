using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed;
    private EnemyController eController;
    private float timeMultiplier = 1;
    private int horizontal;
    private int horizontalInput;
    private int vertical;
    private int verticalInput;
    private Vector2 direction;


    public void SetMultiplier(float value) { timeMultiplier = value; }
    public void SetHorizontal(int value) { horizontalInput = value; }

    public void SetVertical(int value) { verticalInput = value; }

    void Start()
    {
        eController = this.GetComponent<EnemyController>();
    }

    void Update()
    {
        setDirection();
        move();
    }

    private void setDirection()
    {
        if (horizontalInput == 1 && eController.eCollision.GetCollisionType("Right") ||
                horizontalInput == -1 && eController.eCollision.GetCollisionType("Left"))
            horizontal = 0;
        else
            horizontal = horizontalInput;
        if (verticalInput == 1 && eController.eCollision.GetCollisionType("Up") ||
                verticalInput == -1 && eController.eCollision.GetCollisionType("Down"))
            vertical = 0;
        else
            vertical = verticalInput;
        
        direction = new Vector2(horizontal, vertical).normalized;
    }

    private void move()
    {
        transform.Translate(direction * speed * Time.deltaTime * timeMultiplier);
    }
}
