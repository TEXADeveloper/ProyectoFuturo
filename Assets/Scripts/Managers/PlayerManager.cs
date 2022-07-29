using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController pController;

    void Start()
    {
        InputManager.IM?.SetPlayerManager(this);
        pController = player.GetComponent<PlayerController>();
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
