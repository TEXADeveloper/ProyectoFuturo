using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerCollision pCollision;
    [HideInInspector] public PlayerTime pTime;

    void Start()
    {
        pMovement = this.GetComponent<PlayerMovement>();
        pCollision = this.GetComponent<PlayerCollision>();
        pTime = this.GetComponent<PlayerTime>();
    }
}
