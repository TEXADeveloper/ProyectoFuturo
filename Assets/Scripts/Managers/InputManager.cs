using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;
    private PlayerManager pM;

    void Awake()
    {
        if (IM != null)
            Destroy(this.gameObject);
        else
            IM = this;
        DontDestroyOnLoad(this);
    }

    public void SetPlayerManager(PlayerManager script) { pM = script; }

    void OnHorizontal(InputValue value)
    {
        pM.ReceiveInput("Horizontal", int.Parse(value.Get().ToString()));
    }

    void OnVertical(InputValue value)
    {
        pM.ReceiveInput("Vertical", int.Parse(value.Get().ToString()));
    }
}
