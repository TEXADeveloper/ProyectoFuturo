using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyController eController;
    
    void Start()
    {
        eController = this.GetComponent<EnemyController>();
    }

    void Update()
    {/*
        if jugador no está en área
            caminar por la ruta
        if jugador está en área
            correr hacia él
            if jugador está en área de disparo
                disparar
        else
            error xD
    */}
}
