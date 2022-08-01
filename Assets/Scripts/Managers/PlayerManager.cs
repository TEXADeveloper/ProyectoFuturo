using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CameraFollow cameraFollow;
    private GameObject player;
    private PlayerController pController;

    void Start()
    {
        InputManager.IM?.SetPlayerManager(this);
        SpawnPlayer();
        pController = player.GetComponent<PlayerController>();
    }

    private void SpawnPlayer()
    {
        player = GameObject.Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity, this.transform);
        cameraFollow.playerTransform = player.transform;
    }

    public void ReceiveInput(string key, int value)
    {
        switch(key)
        {
            case "Horizontal":
                pController?.pMovement.SetHorizontal(value);
                break;
            case "Vertical":
                pController?.pMovement.SetVertical(value);
                break;
            case "FastTime":
                pController?.pTime.Input(value);
                break;
            default:
                Debug.LogError("No se encuentra la key: " + key);
                break;
        }
    }
}
