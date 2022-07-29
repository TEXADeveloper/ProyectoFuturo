using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pMovement;

    void Start()
    {
        pMovement = this.GetComponent<PlayerMovement>();
    }
}
