using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    private InputAction resetAction;

    public Vector2 spawnPoint;

    void Start()
    {
        resetAction = InputSystem.actions.FindAction("Reset");
        spawnPoint = transform.position;
    }

    void Update()
    {
        if (resetAction.WasPressedThisFrame())
        {
            SceneManagment.instance.ReloadCurrentScene();
        }
    }

#region Collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            TimerManager.instance.CompleteLevel();
        }

        if (collision.CompareTag("Killfloor"))
        {
            PlayerDeath();
        }

        if (collision.CompareTag("SpawnPoint"))
        {
            spawnPoint = collision.transform.position;
        }
    }
#endregion

    void PlayerDeath()
    {
        transform.position = spawnPoint;
    }

}
