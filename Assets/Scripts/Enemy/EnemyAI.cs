using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] checkPoints;
    [SerializeField, Range(0f, 1f)] float touchDistance;
    private EnemyController eController;
    private Transform lastCheckpoint = null;
    private Transform theOneBeforeLastCheckpoint = null;
    
    void Start()
    {
        eController = this.GetComponent<EnemyController>();
    }

    void Update()
    {
        //if jugador no está en área
        Transform nearestCheckpoint = findNearestCheckpoint();   
        setDirection(nearestCheckpoint);
        /*if jugador está en área
            correr hacia él
            if jugador está en área de disparo
                disparar
        else
            error xD*/
    }

    private Transform findNearestCheckpoint()
    {
        Transform nearestTransform = null;
        float distanceToNearest = float.MaxValue - 0.1f;
        foreach (Transform checkPoint in checkPoints)
        {
            float distanceToCompare = float.MaxValue;
            if (checkPoint != lastCheckpoint && checkPoint!= theOneBeforeLastCheckpoint)
                distanceToCompare = getDistance(checkPoint.position, transform.position);
            if (distanceToCompare < distanceToNearest)
            {
                distanceToNearest = distanceToCompare;
                nearestTransform = checkPoint;
                if (distanceToNearest <= touchDistance && distanceToNearest > 0f)
                {
                    theOneBeforeLastCheckpoint = lastCheckpoint;
                    lastCheckpoint = nearestTransform;
                }
            }
        }
        return nearestTransform;
    }

    private float getDistance(Vector3 d1, Vector3 d2)
    {
        float x = Mathf.Abs(d1.x-d2.x);
        float y = Mathf.Abs(d1.y-d2.y);
        float distance = Mathf.Sqrt(Mathf.Pow(x,2) + Mathf.Pow(y,2));
        return distance;
    }

    private void setDirection(Transform checkPoint)
    {
        Vector2 direction = getDirection(checkPoint.position);
        eController.eMovement.SetHorizontal((int) direction.x);
        eController.eMovement.SetVertical((int) direction.y);
    }

    private Vector2 getDirection(Vector2 point)
    {
        Vector2 direction = Vector2.zero;
        float xDistance = point.x - transform.position.x;
        float yDistance = point.y - transform.position.y;
        direction = new Vector2(dirFromDistance(xDistance), dirFromDistance(yDistance));
        return direction;
    }

    private int dirFromDistance(float distance)
    {
        if (distance > 0)
            return 1;
        else if (distance < 0)
            return -1;
        else
            return 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
