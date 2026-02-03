using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    private InputAction resetAction;

    void Start()
    {
        resetAction = InputSystem.actions.FindAction("Reset");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            TimerManager.instance.CompleteLevel();
        }
    }

    void Update()
    {
        if (resetAction.WasPressedThisFrame())
        {
            SceneManagment.instance.ReloadCurrentScene();
        }
    }
}
